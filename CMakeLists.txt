cmake_minimum_required(VERSION 3.21)

set( CMAKE_SUPPORT_WINDOWS_EXPORT_ALL_SYMBOLS 1 )
set(WINDOWS_EXPORT_ALL_SYMBOLS ON)

project(yoga-sharp)
set(CMAKE_VERBOSE_MAKEFILE on)

include(CheckIPOSupported)

set(YOGA_ROOT ${CMAKE_CURRENT_SOURCE_DIR}/YogaCpp)
include(${YOGA_ROOT}/cmake/project-defaults.cmake)


file(GLOB SOURCES CONFIGURE_DEPENDS
    ${YOGA_ROOT}/yoga/*.cpp
    ${YOGA_ROOT}/yoga/**/*.cpp)

add_library(yoga SHARED ${SOURCES})

# Yoga conditionally uses <android/log> when building for Android
if (ANDROID)
    target_link_libraries(yoga log)
endif()

check_ipo_supported(RESULT result)
if(result)
  set_target_properties(yoga PROPERTIES
    CMAKE_INTERPROCEDURAL_OPTIMIZATION true)
endif()

target_include_directories(yoga
    PUBLIC
    $<BUILD_INTERFACE:${YOGA_ROOT}>
    $<INSTALL_INTERFACE:${CMAKE_INSTALL_PREFIX}/include/yoga>)

set_target_properties(yoga PROPERTIES PREFIX "")
target_compile_options(yoga PRIVATE -static)
