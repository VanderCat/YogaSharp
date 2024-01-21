cmake_minimum_required(VERSION 3.13...3.26)
project(yoga-sharp)
set(CMAKE_VERBOSE_MAKEFILE on)

set(YOGA_ROOT ${CMAKE_CURRENT_SOURCE_DIR}/YogaCpp)
include(${YOGA_ROOT}/cmake/project-defaults.cmake)

add_subdirectory(${YOGA_ROOT}/yoga ${CMAKE_CURRENT_BINARY_DIR}/yoga)

add_library(yoga SHARED $<TARGET_OBJECTS:yogacore>)
target_link_libraries(yoga yogacore)