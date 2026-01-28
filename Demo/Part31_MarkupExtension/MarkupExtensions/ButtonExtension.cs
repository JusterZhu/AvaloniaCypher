namespace Part31_MarkupExtension.MarkupExtensions;

public class ButtonExtension
{
    public object? Content { get; set; }

    [UsedImplicitly]
    public Button ProvideValue() => new()
    {
        Content = Content
    };
}

public class ButtonBindingExtension
{
    public IBinding? Content { get; set; }

    [UsedImplicitly]
    public Button ProvideValue()
    {
        return new Button
        {
            [!ContentControl.ContentProperty] = Content ?? new Binding()
        };
    }
}

public class ButtonStyledExtension : AvaloniaObject
{
    public static readonly StyledProperty<object?> ContentProperty =
        ContentControl.ContentProperty.AddOwner<ButtonStyledExtension>();

    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    [UsedImplicitly]
    public Button ProvideValue() => new()
    {
        [!ContentControl.ContentProperty] = this[!ContentProperty]
    };
}

public class ButtonDerivedExtension : Button
{
    [UsedImplicitly]
    public Button ProvideValue() => this;

    /// <inheritdoc />
    protected override Type StyleKeyOverride => typeof(Button);
}