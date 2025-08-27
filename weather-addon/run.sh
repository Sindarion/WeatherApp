#!/bin/sh
set -e

# Default values if not passed
IP=${ADDON_IP:-0.0.0.0}
PORT=${ADDON_PORT:-5000}

echo "Starting API on http://$IP:$PORT ..."
exec dotnet api.dll --urls "http://$IP:$PORT"
