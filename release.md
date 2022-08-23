# Phase CSharp
***WARNING: This is an early alpha release so may be unstable with breaking changes and have missing documentaiton. Use with caution.***

Built using:
 - Phase [v0.1.2-11](https://github.com/i3drobotics/phase/releases/tag/v0.1.2-11)
 - .NET v5.0

See [Phase Unity](https://github.com/i3drobotics/phase-unity.git) for an example of how these binaries are used.

Documentation is available [here](https://i3drobotics.github.io/phase-csharp/)

## Changelog
### Improvements
- Add documentation for all classes
- Add documentation for all tests
- Add CameraCalibration class
- Upgrade to Phase v0.1.2-11
    - Improved placement of types in code file structure
    - Add C-API for CameraCalibration class
    - Consistent naming convension for C-API

### Breaking changes
- Phase v0.1.2-11 upgrade has breaking changes
    - Removed StereoProcess and StereoVision
    - Removed RGBDVideoStreamer and RGBDVideoWriter
    - Moved CameraDeviceInfo from 'types' to 'stereocamera' folder
    - Moved all contents in 'types/common.cs' to other classes and removed 'types/common.cs'
    - Moved StereoMatcherType and StereoMatcherComputeResult to AbstractStereoMatcher
    - Moved CameraReadResult to AbstractStereoCamera
    - Created 'types/stereo.cs'
    - Moved StereoImagePair to 'types/stereo.cs'
    - Renamed phaseversion.cs to version.cs
- Added namespaces: 'I3DR.Phase.types', 'I3DR.Phase.stereocamera', 'I3DR.Phase.stereomatcher', 'I3DR.Phase.calib'
- Moved classes to specific namespaces
- Moved Phase C-API dllImports to phasec folder
- Added namespace for C-API ('I3DR.CPhase')
- Added namespaces: 'I3DR.CPhase.types', 'I3DR.CPhase.stereocamera', 'I3DR.CPhase.stereomatcher', 'I3DR.CPhase.calib'
- Moved Phase C-API classes to specific namespaces