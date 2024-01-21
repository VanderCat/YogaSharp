# YogaSharp
A facebook/yoga layout engine bindings for C# programming language

Yoga.Interop bindings are generated using ClangSharp

## Generating Yoga.Interop
install ClangSharpPInvokeGenerator and then run `generation.ps1`/`generaion.sh`
```shell
dotnet tool install --global ClangSharpPInvokeGenerator
```
## Building notes
you need to compile a (lib)yoga.dll/.so and place it in YogaCpp/build/ (or you can just build it rn)
```shell
cmake . -B YogaCpp/build -G Ninja
cd YogaCpp/build 
ninja
```