# --- Environment variable check ---
# In your deploy script:
# Load .env file
if (Test-Path .env) {
    Get-Content .env | ForEach-Object {
        if ($_ -match '^\s*([^#][^=]*?)\s*=\s*(.+?)\s*$') {
            $name = $matches[1]
            $value = $matches[2]
            # Remove quotes if present
            $value = $value -replace '^["'']|["'']$'
            Set-Variable -Name $name -Value $value -Scope Script
        }
    }
} else {
    Write-Error ".env file not found. Copy .env.example and configure it."
    exit 1
}

# Validate required variables
$required = @(
    "LGSM_STAGE_IP",
    "LGSM_STAGE_USER",
    "LGSM_STAGE_USER_PASS"
)

foreach ($v in $required) {
    if (-not (Get-Variable -Name $v -Scope Script -ErrorAction SilentlyContinue).Value) {
        Write-Error "Variable '$v' is not defined in .env"
        exit 1
    }
}
Write-Host "User: [$LGSM_STAGE_USER]"
Write-Host "Password: [$LGSM_STAGE_USER_PASS]"
Write-Host "Host: [$LGSM_STAGE_IP]"
# --- Publish ---
dotnet publish GameServerManager.Dashboard/GameServerManager.Dashboard.csproj -c Release -o GameServerManager.Dashboard/bin/Release/net10.0/publish -p:BlazorEnableCompression=false
dotnet publish GameServerManager.Dashboard/GameServerManager.Dashboard.csproj -c Release --no-restore --no-build -o GameServerManager.Dashboard/bin/Release/net10.0/publish -p:BlazorEnableCompression=false

# --- Remote directory setup ---
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "mkdir -p /home/lgsm/blazor_lgsm"
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "chown lgsm:lgsm /home/lgsm/blazor_lgsm"
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "chmod 0755 -R /home/lgsm/blazor_lgsm"
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "mkdir -p /usr/share/webmin/blazor_lgsm/wwwroot"
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "chmod 0755 -R /usr/share/webmin/blazor_lgsm"
plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "rm -R /usr/share/webmin/blazor_lgsm/wwwroot/*"

plink -batch $LGSM_STAGE_USER@$LGSM_STAGE_IP -pw "$LGSM_STAGE_USER_PASS" "mkdir -p /tmp"

$wbmFile = Get-ChildItem "GameServerManager.Dashboard/bin/out" -Filter "blazor_lgsm-*.wbm.gz" | Select-Object -First 1

if (-not $wbmFile) {
    Write-Error "No .wbm.gz package found in output directory"
    exit 1
}

Write-Host "Found package: $($wbmFile.Name)"

# Upload
pscp -batch -pw "$LGSM_STAGE_USER_PASS" $wbmFile.FullName ${LGSM_STAGE_USER}@${LGSM_STAGE_IP}:/tmp/

# --- Reinstall Module ---
plink -batch ${LGSM_STAGE_USER}@${LGSM_STAGE_IP} -pw "$LGSM_STAGE_USER_PASS" "perl /usr/share/webmin/install-module.pl /tmp/$($wbmFile.Name)"