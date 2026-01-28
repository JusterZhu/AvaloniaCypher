namespace Part31_MarkupExtension.MarkupExtensions;

public class GenericExtension<T>
{
    public T? Value { get; set; }

    [UsedImplicitly]
    public T? ProvideValue() => Value;
}

public class GenericExtension<T, TReturn>
{
    public T? Value { get; set; }

    [UsedImplicitly]
    public TReturn? ProvideValue() => default;
}
