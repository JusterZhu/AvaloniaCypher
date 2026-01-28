using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class MultiReturnExtension : MarkupExtension
{
    public string ProvideTypedValue() => "Hello from MultiReturnExtension!";

    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider) => ProvideTypedValue();
}
