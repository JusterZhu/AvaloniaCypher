namespace Part31_MarkupExtension.MarkupExtensions;

public class DuckTypeExtension
{
    [UsedImplicitly]
    // public string ProvideValue() => "DuckTypeExtension 1";
    // public object ProvideValue() => "DuckTypeExtension 2";
    // public string ProvideValue(IServiceProvider serviceProvider) => "DuckTypeExtension 3";
    public object ProvideValue(IServiceProvider serviceProvider) => "DuckTypeExtension 4";
}
