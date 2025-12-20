#!/bin/bash

IMG="/home/lgsm/blazor_lgsm/scripts/server_banner.jpg"

echo "Content-Type: image/jpeg"
echo ""

cat "$IMG"