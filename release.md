# Phase CSharp
***WARNING: This is an early alpha release so may be unstable with breaking changes and have missing documentaiton. Use with caution.***

Built using:
 - Phase [v0.1.2-14](https://github.com/i3drobotics/phase/releases/tag/v0.1.2-14)
 - .NET v5.0

See [Phase Unity](https://github.com/i3drobotics/phase-unity.git) for an example of how these binaries are used.

Documentation is available [here](https://i3drobotics.github.io/phase-csharp/)

## Changelog
### Improvements
- Added documentation for all classes [#7](https://github.com/i3drobotics/phase-csharp/pull/7)
- Added documentation for all tests [#8](https://github.com/i3drobotics/phase-csharp/pull/8)
- Added CameraCalibration class
- Added getter methods for parameters to CameraCalibration class [#14](https://github.com/i3drobotics/phase-csharp/pull/14)
- Added toMono function to Utils class [#15](https://github.com/i3drobotics/phase-csharp/pull/15)
- Added ability to create stereo matcher from stereo params [#16](https://github.com/i3drobotics/phase-csharp/pull/16)
- Improved tests & demos [#12](https://github.com/i3drobotics/phase-csharp/pull/12)
- Upgrade to Phase v0.1.2-14
    - Improved placement of types in code file structure [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Added C-API for CameraCalibration class [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Consistent naming convension for C-API [#10](https://github.com/i3drobotics/phase-csharp/pull/10)

### Breaking changes
- Phase v0.1.2-14 upgrade has breaking changes
    - Removed StereoProcess and StereoVision [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Removed RGBDVideoStreamer and RGBDVideoWriter [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved CameraDeviceInfo from 'types' to 'stereocamera' folder [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved all contents in 'types/common.cs' to other classes and removed 'types/common.cs' [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved StereoMatcherType and StereoMatcherComputeResult to AbstractStereoMatcher [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved CameraReadResult to AbstractStereoCamera [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Created 'types/stereo.cs' [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved StereoImagePair to 'types/stereo.cs' [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Renamed phaseversion.cs to version.cs [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Rename enableOccInterpol in StereoI3DRSGM to enableOcclusionInterpolation [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
    - Moved timeout to last parameter in the AbstractStereoCamera 'read' and 'startReadThread' functions [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Added namespaces: 'I3DR.Phase.types', 'I3DR.Phase.stereocamera', 'I3DR.Phase.stereomatcher', 'I3DR.Phase.calib' [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Moved classes to specific namespaces [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Moved Phase C-API dllImports to phasec folder [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Added namespace for C-API ('I3DR.CPhase') [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Added namespaces: 'I3DR.CPhase.types', 'I3DR.CPhase.stereocamera', 'I3DR.CPhase.stereomatcher', 'I3DR.CPhase.calib' [#10](https://github.com/i3drobotics/phase-csharp/pull/10)
- Moved Phase C-API classes to specific namespaces [#10](https://github.com/i3drobotics/phase-csharp/pull/10)