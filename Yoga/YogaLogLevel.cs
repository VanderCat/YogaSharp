using Yoga.Interop;

namespace Yoga; 

public enum YogaLogLevel {
    Debug = YGLogLevel.YGLogLevelDebug,
    Error = YGLogLevel.YGLogLevelError,
    Fatal = YGLogLevel.YGLogLevelFatal,
    Info = YGLogLevel.YGLogLevelInfo,
    Warn = YGLogLevel.YGLogLevelWarn,
    Verbose = YGLogLevel.YGLogLevelVerbose
}