using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class FormatTextExtension
{
    public FormatTextExtension()
    {
    }

    public FormatTextExtension(string? text)
    {
        Text = text;
    }

    public FormatTextExtension(string? text, StringCase? @case)
    {
        Text = text;
        Case = @case;
    }

    [ConstructorArgument("text")]
    public string? Text { get; set; }

    [ConstructorArgument("case")]
    public StringCase? Case { get; set; }

    [UsedImplicitly]
    public string? ProvideValue() => Case switch
    {
        StringCase.Upper => Text?.ToUpperInvariant(),
        StringCase.Lower => Text?.ToLowerInvariant(),
        StringCase.Title => Text is not null
            ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text)
            : null,
        _ => Text
    };
}

public enum StringCase
{
    Normal,
    Upper,
    Lower,
    Title
}