#!/bin/bash

# TEMPORARY BUILD SCRIPT WHILE CMAKE ALTERNATIVE IS BROKEN

# exit on command failure
set -e

SCRIPT_PATH="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"

function get_win_drive_path() {
    # convert bash with path like '/c/path/to/folder'
    # to path for use in windows like 'C:\path\to\folder'

    # swap forward slashes for backward slashes
    local BASH_PATH=$1
    local BASH_PATH_BS=${BASH_PATH//\//\\}
    local PATH_CLEAN_START=${BASH_PATH_BS:1}
    local PATH_BEFORE_DRIVE=${PATH_CLEAN_START:0:1}
    local PATH_AFTER_DRIVE=${PATH_CLEAN_START:1}
    local WIN_PATH=$PATH_BEFORE_DRIVE":"$PATH_AFTER_DRIVE
    echo $WIN_PATH
}

cd "$SCRIPT_PATH/build"
cmake -G "Visual Studio 17 2022" -A x64 -T v142 -DPhase_DIR="C:\Program Files\i3DR\Phase\lib\cmake" ..

csharp_unittest_proj="$SCRIPT_PATH/test/build/phasesharp_test.csproj"
csharp_unittest_proj_win=$(get_win_drive_path $csharp_unittest_proj)
sln_path="$SCRIPT_PATH/build/phasesharp.sln"
sln_path_win=$(get_win_drive_path $sln_path)
# add unit test project to solution
dotnet sln "$sln_path_win" add "$csharp_unittest_proj_win"
# define msbuild path
# restore nuget package for project (nuget exe provided)
$SCRIPT_PATH/./nuget.exe restore

cmake --build . --config Release
cmake --build . --config Release --target phasesharp_test

cd $SCRIPT_PATH/build/Release
vswhere_path="/c/Program Files (x86)/Microsoft Visual Studio/Installer/vswhere.exe"
vs_path=$("$vswhere_path" -latest -property installationPath)
vstest_path=$vs_path"/Common7/IDE/CommonExtensions/Microsoft/TestWindow/vstest.console"
"$vstest_path" phasesharp_test.dll /platform:x64
