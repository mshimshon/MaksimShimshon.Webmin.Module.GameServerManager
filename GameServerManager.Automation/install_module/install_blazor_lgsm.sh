#!/bin/bash

REPO_OWNER="mshimshon"
REPO_NAME="MaksimShimshon.Webmin.Module.GameServerManager"
ASSET_NAME="blazor_lgsm.wbm.gz"
MODULE_NAME="blazor_lgsm"
WEBMIN_DIR="/usr/share/webmin"

# Get latest release download URL
LATEST_RELEASE=$(curl -s "https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/releases/latest")
DOWNLOAD_URL=$(echo "$LATEST_RELEASE" | grep -oP '"browser_download_url":\s*"\K[^"]+' | head -n 1)

if [ -z "$DOWNLOAD_URL" ]; then
    echo "Error: Could not find download URL for latest release"
    exit 1
fi

echo "Downloading from: $DOWNLOAD_URL"
wget -O "${ASSET_NAME}" "$DOWNLOAD_URL"

if [ $? -ne 0 ]; then
    echo "Error: Download failed"
    exit 1
fi

echo "Extracting .gz archive..."
gunzip "${ASSET_NAME}"

# After gunzip, find the .wbm file
WBM_FILE=$(ls blazor_lgsm*.wbm 2>/dev/null | head -n 1)

if [ -z "$WBM_FILE" ]; then
    echo "Error: .wbm file not found after extraction"
    exit 1
fi

echo "Found: $WBM_FILE"

# Create target directory
mkdir -p "$MODULE_NAME"

echo "Extracting .wbm archive into ${MODULE_NAME}/..."
tar -xvf "$WBM_FILE" -C "$MODULE_NAME"

if [ $? -eq 0 ]; then
    echo "Extraction complete!"
    echo "Module contents in: ${MODULE_NAME}/"
    ls -la "${MODULE_NAME}/"
else
    echo "Error: Failed to extract .wbm file"
    exit 1
fi

# Optional: Clean up the .wbm file
rm "$WBM_FILE"
rm "$ASSET_NAME"

# Remove old module
echo "Removing old module..."
rm -rf "${WEBMIN_DIR}/${MODULE_NAME}"

# Move new module into place
echo "Installing new module..."
mv "${MODULE_NAME}" "${WEBMIN_DIR}/"

# Set permissions
echo "Fixing Permissions"
chown -R root:root "${WEBMIN_DIR}/${MODULE_NAME}"
chmod -R 755 "${WEBMIN_DIR}/${MODULE_NAME}"

echo "Restarting Webmin..."
systemctl restart webmin
echo "Done! "