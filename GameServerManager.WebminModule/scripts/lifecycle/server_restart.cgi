#!/bin/bash
echo "Content-Type: application/json"
echo ""

# STEP 1 — Start server
sudo -u lgsm /home/lgsm/blazor_lgsm/start_restart.sh >/dev/null 2>&1 &