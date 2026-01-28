namespace Part31_MarkupExtension.MarkupExtensions;

public class ControlInfoExtension
{
    [ResolveByName]
    public object? Control { get; set; }

    [UsedImplicitly]
    public string ProvideValue() =>
        $"{Control?.GetType()} ({(Control as Control)?.Name})";
}
