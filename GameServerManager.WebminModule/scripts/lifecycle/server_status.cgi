#!/bin/bash
echo "Content-Type: application/json"
echo ""

# Run your script as LGSM user and output directly
sudo -u lgsm /home/lgsm/blazor_lgsm/update_server_details.sh