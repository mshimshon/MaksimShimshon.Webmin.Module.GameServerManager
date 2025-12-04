#!/bin/bash

IMG="/home/lgsm/blazor_lgsm/server_banner.jpg"

echo "Content-Type: image/jpeg"
echo ""

cat "$IMG"