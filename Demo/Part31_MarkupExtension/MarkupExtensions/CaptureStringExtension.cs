using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class CaptureStringExtension(string? text)
{
    [ConstructorArgument("text")]
    public string? Text { get; set; } = text;

    [UsedImplicitly]
    public string? ProvideValue() => Text;
}
