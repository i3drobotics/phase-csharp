# Phase CSharp
Phase CSharp is a C# wrapper library over the Phase C++ library to enable running Phase in C#.

**NOTE: This package is still in development with missing functionality. Updates coming soon.**
## Install
Download Phase CSharp library from [latest release](https://github.com/i3drobotics/phase-csharp/releases)  
This includes the binararies for running and using Phase CSharp.

## Dependencies
### Phase
Phase library is required to be installed for use in the build process.  
Download Windows installer from the [v0.0.20 release](https://github.com/i3drobotics/phase/releases/tag/v0.0.20).  
Install using the installer GUI, this should install to `C:\Program Files\i3DR\Phase`
### Visual Studio
Visual Studio is required to build the Phase CSharp library. The following components are required:
- `.NET desktop development tools`
- `.Net Framework 4.7.2 development tools`
- `C# and Visual Basic`

### Additional dependencies
Doxygen is used for documentation.  
On Windows download and install doxygen from [here](https://www.doxygen.nl/download.html)

## Build
```bash
dotnet build
```

## Test

### Unit test
Unit testing is performed by xunity.  
To run the tests, use the following commands:
```bash
dotnet test
```
*Note: Make sure to run this from the project root directory*  
Alternatively, after building run the tests graphically using Visual Studio and Test Explorer.  

### Apps
To run the test applications, use the following commands:
```bash
dotnet run --project=test/drivers/demo_cam_read/PhaseCSharp.demo_cam_read.csproj 
dotnet run --project=test/drivers/demo_rgbd/PhaseCSharp.demo_rgbd.csproj 
```

*Note: Make sure to run this from the project root directory*

## Install
TODO

## Docs
Documentation is generated and deployed in GitHub actions, however, to test documentation generation locally, run the following commands:
```bash
./docs/gen_docs.sh
```
This requires [doxygen](https://www.doxygen.nl/index.html) to be installed and available on the path.
