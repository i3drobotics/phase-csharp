# Lowest version with C# support is 3.8.
# Lowest version that supports VS 2019 is 3.14.
CMAKE_MINIMUM_REQUIRED(VERSION 3.14)

if (NOT (WIN32 OR UNIX OR APPLE))
    message(FATAL_ERROR "Unsupport os. WIN32, UNIX and APPLE currently supported.")
endif ()

# Create temporary version file if it does not exist
# Automatic versioning is handelled by GitHub workflow so 0.0.0 is used when running locally
if(NOT EXISTS "${CMAKE_SOURCE_DIR}/version.txt")
    file(WRITE "${CMAKE_SOURCE_DIR}/version.txt" "0.0.0")
endif()

# Read version from file
file(READ "${CMAKE_SOURCE_DIR}/version.txt" ver)
string(REGEX REPLACE "(\r?\n)+" "" ver ${ver}) # remove newlines
message("version: ${ver}")

project(PhaseSharp LANGUAGES CSharp CXX VERSION ${ver})

# Define names
string(TOUPPER ${PROJECT_NAME} PROJECT_NAME_UPPER)
string(TOLOWER ${PROJECT_NAME} PROJECT_NAME_LOWER)

# Set global .NET Framework version.
SET(CMAKE_DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2")

# Set the C# language version for all projects.
SET(CMAKE_CSharp_FLAGS "/langversion:6")

# Explicitly set the `PlatformTarget` for C# projects, since AnyCPU can result in 
# System.BadImageFormatException throws, when trying to load C++/CLI assemblies.
IF(CMAKE_GENERATOR_PLATFORM STREQUAL "x64")
  SET(CMAKE_CSharp_FLAGS "/platform:x64")
ELSEIF(CMAKE_GENERATOR_PLATFORM STREQUAL "Win32")
    SET(CMAKE_CSharp_FLAGS "/platform:x86")
ELSE()
  MESSAGE(WARNING "Generator platform is set to '${CMAKE_GENERATOR_PLATFORM}', which is not supported by managed projects. Defaulting to 'AnyCPU'...")
  SET(CMAKE_CSharp_FLAGS "/platform:AnyCPU")
ENDIF()

SET(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

option(BUILD_TESTS "Build Unit tests" OFF)

# Find Phase
find_package(Phase REQUIRED)

file (GLOB PHASE_LIBRARY_FILES
    "${Phase_DIR}/../../bin/*.dll"
)

# Define C# include/source files
file (GLOB SRC_FILES
    "src/*.cs"
    "src/types/*.cs"
    "src/calib/*.cs"
    "src/stereocamera/*.cs"
    "src/stereomatcher/*.cs"
)

if (BUILD_TESTS)
    file (GLOB UNIT_TEST_SRC_FILES
        "test/src/*.cs"
        "test/src/types/*.cs"
        "test/src/calib/*.cs"
        "test/src/stereocamera/*.cs"
        "test/src/stereomatcher/*.cs"
    )
endif()

# Create assembly info with current version.
CONFIGURE_FILE("${CMAKE_SOURCE_DIR}/src/AssemblyInfo.cs.template" "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs")

set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Build C# library
add_library(${PROJECT_NAME_LOWER} SHARED 
    "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs"
    ${SRC_FILES}
)
set_target_properties(${PROJECT_NAME_LOWER} PROPERTIES
    VS_DOTNET_REFERENCES "System;System.Core"
    VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
)
set_target_properties(${PROJECT_NAME_LOWER} PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin
    RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/bin
    RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/bin
    LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib
    LIBRARY_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/lib
    LIBRARY_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/lib
)
add_custom_command(TARGET ${PROJECT_NAME_LOWER} POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy
    ${PHASE_LIBRARY_FILES} ${CMAKE_BINARY_DIR}/bin
)

if(BUILD_TESTS)
    # Build C# library
    add_library(${PROJECT_NAME_LOWER}_test SHARED ${UNIT_TEST_SRC_FILES})
    target_link_libraries(${PROJECT_NAME_LOWER}_test PRIVATE ${PROJECT_NAME_LOWER})
    set_target_properties(${PROJECT_NAME_LOWER}_test PROPERTIES
        VS_DOTNET_REFERENCES "System;System.Core"
        VS_PACKAGE_REFERENCES "MSTest.TestAdapter_2.2.8;MSTest.TestFramework_2.2.8"
        VS_GLOBAL_TestProjectType "UnitTest"
        VS_GLOBAL_PROJECT_TYPES "{3AC096D0-A1C2-E12C-1390-A8335801FDAB};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
        VS_GLOBAL_IsTestProject "true"
    )
    set_target_properties(${PROJECT_NAME_LOWER}_test PROPERTIES
        RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/bin
        LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/lib
    )

    # Build C# rgbd demo app
    add_executable(${PROJECT_NAME_LOWER}_demo_rgbd test/drivers/demo_rgbd.cs)
    target_link_libraries(${PROJECT_NAME_LOWER}_demo_rgbd PRIVATE ${PROJECT_NAME_LOWER})
    set_property(TARGET ${PROJECT_NAME_LOWER}_demo_rgbd PROPERTY VS_DOTNET_REFERENCES
        "System"
        "System.Drawing"
        "System.Windows.Forms"
    )
    set_target_properties(${PROJECT_NAME_LOWER}_demo_rgbd PROPERTIES
        RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/bin
        LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/lib
    )

    # Build C# camera read app
    add_executable(${PROJECT_NAME_LOWER}_demo_cam_read test/drivers/demo_cam_read.cs)
    target_link_libraries(${PROJECT_NAME_LOWER}_demo_cam_read PRIVATE ${PROJECT_NAME_LOWER})
    set_property(TARGET ${PROJECT_NAME_LOWER}_demo_cam_read PROPERTY VS_DOTNET_REFERENCES
        "System"
        "System.Drawing"
        "System.Windows.Forms"
    )
    set_target_properties(${PROJECT_NAME_LOWER}_demo_cam_read PROPERTIES
        RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/bin
        RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/bin
        LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/lib
        LIBRARY_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/lib
    )

    install(TARGETS ${PROJECT_NAME_LOWER}_demo_rgbd
        RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
        LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
        ARCHIVE DESTINATION ${CMAKE_INSTALL_LIBDIR}
    )

    install(TARGETS ${PROJECT_NAME_LOWER}_demo_cam_read
        RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
        LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
        ARCHIVE DESTINATION ${CMAKE_INSTALL_LIBDIR}
    )

    add_custom_command(
        TARGET ${PROJECT_NAME_LOWER}_test POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy_directory
            ${PROJECT_SOURCE_DIR}/test/data/
            ${CMAKE_BINARY_DIR}/bin/data)

    install(DIRECTORY ${PROJECT_SOURCE_DIR}/test/data/ DESTINATION bin/data)

endif()

install(TARGETS ${PROJECT_NAME_LOWER}
    RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    ARCHIVE DESTINATION ${CMAKE_INSTALL_LIBDIR}
)

install(FILES
    ${PHASE_LIBRARY_FILES}
    DESTINATION bin
)

# Install LICENSE file in install folder
install(FILES LICENSE DESTINATION bin)