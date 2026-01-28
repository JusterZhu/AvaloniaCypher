using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace Part31_MarkupExtension.MarkupExtensions;

public class ThicknessDoubleConverter : IValueConverter
{
    public ThicknessDoubleConverter()
    {
    }

    public ThicknessDoubleConverter(ThicknessSide sides)
    {
        Sides = sides;
    }

    [ConstructorArgument("sides")]
    public ThicknessSide Sides { get; set; } = ThicknessSide.All;

    [UsedImplicitly]
    public IValueConverter ProvideValue() => this;

    /// <inheritdoc />
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not double thickness)
            return BindingOperations.DoNothing;
        return new Thickness(
            Sides.HasFlag(ThicknessSide.Left) ? thickness : 0,
            Sides.HasFlag(ThicknessSide.Top) ? thickness : 0,
            Sides.HasFlag(ThicknessSide.Right) ? thickness : 0,
            Sides.HasFlag(ThicknessSide.Bottom) ? thickness : 0
        );
    }

    /// <inheritdoc />
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}

[Flags]
public enum ThicknessSide
{
    None = 0,
    Left = 1 << 0,
    Top = 1 << 1,
    Right = 1 << 2,
    Bottom = 1 << 3,
    All = Left | Top | Right | Bottom
}
