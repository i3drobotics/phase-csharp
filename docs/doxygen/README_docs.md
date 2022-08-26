# Phase CSharp
Phase CSharp is a C# wrapper over the Phase C++ library to enable running Phase in C#.

## Install
Download Phase CSharp library from [latest release](https://github.com/i3drobotics/phase-csharp/releases)  
This includes the binararies for running and using Phase CSharp.

## Dependencies
### Phase
Phase library is required to be installed for use in the build process.  
Download Windows installer from the [v0.1.2-11 release](https://github.com/i3drobotics/phase/releases/tag/v0.1.2-11).  
Install using the installer GUI, this should install to `C:\Program Files\i3DR\Phase`
### Dotnet
.NET 5.0 is required to build the Phase CSharp library. Download and install from [here](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)

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
dotnet run --project=test/demo/demo_cam_read/PhaseCSharp.demo_cam_read.csproj
```

*Note: Make sure to run this from the project root directory*

## Docs
Documentation is generated and deployed in GitHub actions, however, to test documentation generation locally, run the following commands:
```bash
./docs/gen_docs.sh
```
This requires [doxygen](https://www.doxygen.nl/index.html) to be installed and available on the path.
