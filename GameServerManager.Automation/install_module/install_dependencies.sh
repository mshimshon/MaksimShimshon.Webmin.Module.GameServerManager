#!/bin/bash
set -euo pipefail

# If no arguments provided, exit
if [ $# -eq 0 ]; then
    echo "Usage: $0 pkg1 pkg2 pkg3 ..."
    exit 1
fi

# Packages come from arg0..N
PACKAGES=("$@")
ROLLBACK_LIST=""

rollback() {
    echo "Rolling back..."
    if [ -n "$ROLLBACK_LIST" ]; then
        apt-get remove -y $ROLLBACK_LIST || true
    fi
}

trap rollback ERR

echo "Updating package lists..."
apt-get update -y

echo "Installing packages: ${PACKAGES[*]}"
for pkg in "${PACKAGES[@]}"; do
    if dpkg -s "$pkg" >/dev/null 2>&1; then
        echo "$pkg already installed."
    else
        apt-get install -y "$pkg"
        ROLLBACK_LIST="$ROLLBACK_LIST $pkg"
    fi
done

echo "All packages installed successfully."