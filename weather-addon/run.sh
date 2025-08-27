#!/bin/bash
set -e

# Default values
PORT=5000
IP=0.0.0.0

# Read HA options.json if available
if [ -f /data/options.json ]; then
  PORT=$(jq -r '.port // "5000"' /data/options.json)
  IP=$(jq -r '.ip // "0.0.0.0"' /data/options.json)
fi

echo "Starting API on http://$IP:$PORT"
/usr/bin/dotnet api.dll --urls "http://$IP:$PORT"
