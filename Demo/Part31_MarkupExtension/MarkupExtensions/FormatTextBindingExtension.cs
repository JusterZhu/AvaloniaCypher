using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class FormatTextBindingExtension
{
    public FormatTextBindingExtension()
    {
    }

    public FormatTextBindingExtension(IBinding? text)
    {
        Text = text;
    }

    public FormatTextBindingExtension(IBinding? text, IBinding? @case)
    {
        Text = text;
        Case = @case;
    }

    [ConstructorArgument("text")]
    public IBinding? Text { get; set; }

    [ConstructorArgument("case")]
    public IBinding? Case { get; set; }

    [UsedImplicitly]
    public IBinding ProvideValue()
    {
        // return Case switch
        // {
        //     StringCase.Upper => Text?.ToUpperInvariant(),
        //     StringCase.Lower => Text?.ToLowerInvariant(),
        //     StringCase.Title => Text is not null
        //         ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text)
        //         : null,
        //     _ => Text
        // };
        return new MultiBinding
        {
            Bindings =
            {
                Text ?? new Binding(),
                Case ?? new Binding(),
            },
            Converter = new FuncMultiValueConverter<object, string?>(values => values.ToArray() switch
            {
                [string text, StringCase @case] => @case switch
                {
                    StringCase.Upper => text.ToUpperInvariant(),
                    StringCase.Lower => text.ToLowerInvariant(),
                    StringCase.Title => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text),
                    _ => text,
                },
                [string text, _] => text,
                _ => null
            })
        };
    }
}
