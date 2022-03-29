# PhaseSharp
PhaseSharp is a C# library is a wrapper over the Phase C++ library to enable running Phase in C#.

**NOTE: This package is still in development with very little functionality. Updates coming soon.**
## Install
```
TODO 
```

## Dependencies
### Phase
Phase library is required to be installed for use in the build process.  
Download Windows installer from the [v0.0.20 release](https://github.com/i3drobotics/phase-dev/releases/tag/v0.0.20).  
Install using the installer GUI, this should install to `C:\Program Files\i3DR\Phase`
### Visual Studio
Visual Studio is required to build the PhaseSharp library. The following components are required:
- `.NET desktop development tools`
- `.Net Framework 4.8 development tools`
- `C# and Visual Basic`

### Additional dependencies
Doxygen is used for documentation.  
On Windows download and install doxygen from [here](https://www.doxygen.nl/download.html)

## Build
Build Phase Sharp library using CMake:
```bash
mkdir build
cd build
cmake -G "Visual Studio 16 2019" -A x64 -DPhase_DIR="C:/Program Files/i3DR/Phase/lib/cmake" .. 
cmake --build . --config Release -- -r
```
`-- -r` is important for nuget packages to be restored during build.

On Windows, if using Visual Studio 2022 the v142 toolset is still required for dependencies.  
The `MSVC v142 - VS 2019 C++ x64/x86 build tools` component is required to be installed.  
To build with the v142 toolset, use the following command:
```bash
cmake -G "Visual Studio 17 2022" -A x64 -T v142 -DPhase_DIR="C:/Program Files/i3DR/Phase/lib/cmake" ..
```

## Test
To build the library tests enable the CMake option `BUILD_TESTS`:
```bash
cmake -G "Visual Studio 16 2019" -A x64 -DPhase_DIR="C:/Program Files/i3DR/Phase/lib/cmake" -DBUILD_TESTS=ON ..
cmake --build . --config Release -- -r
```

### Unit test
Unit testing is performed by MSTest. You will need to add the vstest.console application to the path in order for it to be found for runnings tests. This is usually found in `C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow`.  
To run the tests, use the following commands:
```bash
cd build/bin
vstest.console phasesharp_test.dll /platform:x64
```
*Note: Make sure to run this from the project root directory*  
Alternatively, after building run the tests graphically using Visual Studio and Test Explorer.  

### Apps
To run the test applications, use the following commands:
```bash
cd build/bin
./phase_demo_cam_read
./phase_demo_rgbd
```

*Note: Make sure to run this from the project root directory*

## Install
To install the library locally, run the following commands:
```bash
cmake -G "Visual Studio 16 2019" -A x64 -DPhase_DIR="C:/Program Files/i3DR/Phase/lib/cmake" -DCMAKE_INSTALL_PREFIX="../install" ..
cmake --build . --config Release --target install -- -r
```
