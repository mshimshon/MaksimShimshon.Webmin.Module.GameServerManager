#!/bin/bash
set -euo pipefail

LGSM_USER="lgsm"
LGSM_HOME="/home/$LGSM_USER"
SUDOERS_FILE="/etc/sudoers.d/lgsm"

if [ $# -ne 1 ]; then
    echo "Usage: $0 <game_server>"
    echo "Example: $0 pzserver"
    exit 1
fi

GAME_SERVER="$1"

if [ -d "/home/lgsm/.steam/steamcmd" ]; then
    echo "Clearing SteamCMD cache..."
    rm -rf "/home/lgsm/.steam/steamcmd/"*
fi

# Step 1: Add lgsm to sudoers without password prompt
echo "Granting temporary sudo privileges to $LGSM_USER..."
echo "$LGSM_USER ALL=(ALL) NOPASSWD:ALL" > "$SUDOERS_FILE"
chmod 440 "$SUDOERS_FILE"

# Ensure lgsm user exists
if ! id "$LGSM_USER" >/dev/null 2>&1; then
    echo "Creating user $LGSM_USER..."
    useradd -m -d "$LGSM_HOME" -s /bin/bash "$LGSM_USER"
    passwd -d "$LGSM_USER"
fi

# Step 2: Run LGSM install as lgsm
echo "Running LGSM install for $GAME_SERVER..."
runuser -l "$LGSM_USER" -c "
    set -euo pipefail
    export DEBIAN_FRONTEND=noninteractive
    cd \"$LGSM_HOME\"
    curl -Lo linuxgsm.sh https://linuxgsm.sh
    chmod +x linuxgsm.sh
    bash ./linuxgsm.sh $GAME_SERVER
    yes y | bash ./$GAME_SERVER install
"

# Step 4: Remove sudoers entry
echo "Revoking sudo privileges from $LGSM_USER..."
rm -f "$SUDOERS_FILE"

echo "LGSM installation for $GAME_SERVER completed successfully."