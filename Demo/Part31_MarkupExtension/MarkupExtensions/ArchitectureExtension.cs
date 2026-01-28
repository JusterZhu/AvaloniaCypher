using System.Runtime.InteropServices;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Metadata;

namespace Part31_MarkupExtension.MarkupExtensions;

public class ArchitectureExtension : IAddChild<On<object>>
{
    [MarkupExtensionOption(nameof(X86))] public object? X86 { get; set; }
    [MarkupExtensionOption(nameof(X64))] public object? X64 { get; set; }
    [MarkupExtensionOption(nameof(Arm))] public object? Arm { get; set; }
    [MarkupExtensionOption(nameof(Arm64))] public object? Arm64 { get; set; }
    [MarkupExtensionOption(nameof(Wasm))] public object? Wasm { get; set; }

    [Content]
    [MarkupExtensionDefaultOption]
    public object? Default { get; set; }

    [UsedImplicitly]
    public static bool ShouldProvideOption(string option)
    {
        Architecture currentArch = RuntimeInformation.ProcessArchitecture;
        return option switch
        {
            nameof(X86) => currentArch == Architecture.X86,
            nameof(X64) => currentArch == Architecture.X64,
            nameof(Arm) => currentArch == Architecture.Arm,
            nameof(Arm64) => currentArch == Architecture.Arm64,
            nameof(Wasm) => currentArch == Architecture.Wasm,
            _ => false,
        };
    }

    // Needed for the compiler.
    public void AddChild(On<object> child) {}
    [UsedImplicitly]
    public object? ProvideValue() => null;
}
