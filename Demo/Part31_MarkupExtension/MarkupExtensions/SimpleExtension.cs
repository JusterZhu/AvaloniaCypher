using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class SimpleExtension : MarkupExtension
{
    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider) => "Hello MarkupExtension";
}
