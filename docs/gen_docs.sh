#!/bin/bash

# exit on command failure
set -e

SCRIPT_PATH="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"

cd "$SCRIPT_PATH/../"

VERSION=$(cat version.txt)
VERSION=${VERSION//$'\n'/} # Remove newlines.
VERSION=${VERSION//$'\r'/} # Remove carriage returns.

# remove previous docs
rm -rf deployment/docs
mkdir -p deployment/docs

# generate docs using doxygen
( cat "$SCRIPT_PATH/../docs/doxygen/Doxyfile" ; echo "PROJECT_NUMBER=$VERSION" ) | "doxygen" -

# create nojekyll file needed for static github pages release
touch deployment/docs/.nojekyll