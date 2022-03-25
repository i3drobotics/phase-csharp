cmake_minimum_required(VERSION 3.9)

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

project(PhaseSharp LANGUAGES CSharp VERSION ${ver})

# Define names
string(TOUPPER ${PROJECT_NAME} PROJECT_NAME_UPPER)
string(TOLOWER ${PROJECT_NAME} PROJECT_NAME_LOWER)

option(BUILD_TESTS "Build Unit tests" OFF)

# Find Phase
find_package(Phase REQUIRED)

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

# Build C# library
add_library(${PROJECT_NAME_LOWER} SHARED ${SRC_FILES})
set_property(TARGET ${PROJECT_NAME_LOWER} PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
)

if(BUILD_TESTS)
    # Build C# library
    add_library(${PROJECT_NAME_LOWER}_test SHARED ${UNIT_TEST_SRC_FILES})
    target_link_libraries(${PROJECT_NAME_LOWER}_test PRIVATE ${PROJECT_NAME_LOWER})
    set_property(TARGET ${PROJECT_NAME_LOWER}_test PROPERTY VS_DOTNET_REFERENCES
        "System"
        "System.Core"
    )
    set_property(TARGET ${PROJECT_NAME_LOWER}_test PROPERTY VS_PACKAGE_REFERENCES
        "MSTest.TestAdapter_2.2.5;MSTest.TestFramework_2.2.5"
    )
    set_target_properties(${PROJECT_NAME_LOWER}_test PROPERTIES
        VS_GLOBAL_TestProjectType "UnitTest"
        VS_GLOBAL_PROJECT_TYPES "{3AC096D0-A1C2-E12C-1390-A8335801FDAB};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
        VS_GLOBAL_IsTestProject "true"
    )

    # Build C# rgbd demo app
    add_executable(${PROJECT_NAME_LOWER}_demo_rgbd test/drivers/demo_rgbd.cs)
    target_link_libraries(${PROJECT_NAME_LOWER}_demo_rgbd PRIVATE ${PROJECT_NAME_LOWER})
    set_property(TARGET ${PROJECT_NAME_LOWER}_demo_rgbd PROPERTY VS_DOTNET_REFERENCES
        "System"
        "System.Drawing"
        "System.Windows.Forms"
    )

    # Build C# camera read app
    add_executable(${PROJECT_NAME_LOWER}_demo_cam_read test/drivers/demo_cam_read.cs)
    target_link_libraries(${PROJECT_NAME_LOWER}_demo_cam_read PRIVATE ${PROJECT_NAME_LOWER})
    set_property(TARGET ${PROJECT_NAME_LOWER}_demo_cam_read PROPERTY VS_DOTNET_REFERENCES
        "System"
        "System.Drawing"
        "System.Windows.Forms"
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

endif()

install(TARGETS ${PROJECT_NAME_LOWER}
    RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    ARCHIVE DESTINATION ${CMAKE_INSTALL_LIBDIR}
)
