#!/bin/bash
set -euo pipefail

# Colors
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

banner() {
    echo -e "${BLUE}============================================================${NC}"
    echo -e "${YELLOW}$1${NC}"
    echo -e "${BLUE}============================================================${NC}"
}

success() {
    echo -e "${GREEN}✔ $1${NC}"
}

error() {
    echo -e "${RED}✖ $1${NC}"
}

info() {
    echo -e "${BLUE}➤ $1${NC}"
}

fail_if_error() {
    local code="$1"
    local step="$2"

    # 141 = SIGPIPE = harmless when using yes in a pipe
    if [[ "$code" -eq 141 ]]; then
        echo -e "${YELLOW}⚠ $step returned SIGPIPE (141) but this is normal. Continuing...${NC}"
        return 0
    fi

    if [[ "$code" -ne 0 ]]; then
        echo -e "${RED}✖ ERROR during: $step (exit code $code)${NC}"
        exit "$code"
    fi
}


if [ $# -ne 1 ]; then
    echo "Usage: $0 <lgsm_game>"
    echo "Example: $0 pzserver"
    exit 1
fi

GAME="$1"
DEPENDENCY_SCRIPT="./install_dependencies.sh"
CONFIGURE_LGSM_SCRIPT="./install_lgsm.sh"
SCRIPT_INSTALL_WEBMIN_BLGSM_MODULE="./install_blazor_lgsm.sh"

export DEBIAN_FRONTEND=noninteractive

banner "Installing Dependencies"
bash "$DEPENDENCY_SCRIPT" locales

success "Dependencies installed successfully."

banner "Configuring UTF-8 Locale"
sed -i 's/^# *en_US.UTF-8 UTF-8/en_US.UTF-8 UTF-8/' /etc/locale.gen
locale-gen en_US.UTF-8
echo 'LANG=en_US.UTF-8' > /etc/default/locale
export LANG=en_US.UTF-8
export LC_ALL=en_US.UTF-8
success "UTF-8 locale configured successfully."

banner "Installing Blazor LGSM Webmin Module"
set +e
yes y | bash "$SCRIPT_INSTALL_WEBMIN_BLGSM_MODULE"
exit_code=$?
set -e
fail_if_error "$exit_code" " Blazor LGSM Webmin Module Installation"
success " Blazor LGSM Webmin Module Installed!"

banner "Configuring LGSM"
set +e
yes y | bash "$CONFIGURE_LGSM_SCRIPT" "$GAME"
exit_code=$?
set -e
fail_if_error "$exit_code" "LGSM configuration"
success "LGSM configured."

banner "Setup Completed"
