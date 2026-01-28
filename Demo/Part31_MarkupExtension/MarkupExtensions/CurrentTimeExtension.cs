using System.Reactive.Linq;

namespace Part31_MarkupExtension.MarkupExtensions;

public class CurrentTimeExtension
{
    [UsedImplicitly]
    public IBinding ProvideValue()
    {
        return Observable
            .Interval(TimeSpan.FromSeconds(1))
            .Select(_ => DateTime.Now)
            .StartWith(DateTime.Now)
            .ToBinding();
    }
}
