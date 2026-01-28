using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.XamlIl.Runtime;

namespace Part31_MarkupExtension.MarkupExtensions;

public class ServiceInspectorExtension
{
    [UsedImplicitly]
    public object? ProvideValue(IServiceProvider serviceProvider)
    {
        INameScope nameScope = serviceProvider.GetRequiredService<INameScope>();
        Slider? slider = nameScope.Find<Slider>("ThicknessSlider");

        IProvideValueTarget provideValueTarget = serviceProvider.GetRequiredService<IProvideValueTarget>();
        Control? targetObject = provideValueTarget.TargetObject as Control;
        AvaloniaProperty? targetProperty = provideValueTarget.TargetProperty as AvaloniaProperty;
        AvaloniaPropertyMetadata? propertyMetadata = targetObject is not null
            ? targetProperty?.GetMetadata(targetObject.GetType())
            : null;

        IAvaloniaXamlIlParentStackProvider parentStackProvider = serviceProvider.GetRequiredService<IAvaloniaXamlIlParentStackProvider>();
        IEnumerable<object> parents = parentStackProvider.Parents;
        IReadOnlyList<object> directParentsStack = parentStackProvider.AsEagerParentStackProvider().DirectParentsStack;

        IRootObjectProvider rootObjectProvider = serviceProvider.GetRequiredService<IRootObjectProvider>();
        object rootObject = rootObjectProvider.RootObject;
        object intermediateRootObject = rootObjectProvider.IntermediateRootObject;

        IAvaloniaXamlIlControlTemplateProvider? controlTemplateProvider = serviceProvider.GetService<IAvaloniaXamlIlControlTemplateProvider>();
        bool isInControlTemplate = controlTemplateProvider is not null;

        IAvaloniaXamlIlXmlNamespaceInfoProvider namespaceInfoProvider = serviceProvider.GetRequiredService<IAvaloniaXamlIlXmlNamespaceInfoProvider>();
        IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> namespaces = namespaceInfoProvider.XmlNamespaces;
        string? xmlAlias = namespaces
            .Where(x => x.Value
                .Any(y =>
                    y.ClrAssemblyName is nameof(Part31_MarkupExtension)
                    && y.ClrNamespace == $"{nameof(Part31_MarkupExtension)}.{nameof(MarkupExtensions)}"))
            .Select(x => x.Key)
            .FirstOrDefault();

        IXamlTypeResolver xamlTypeResolver = serviceProvider.GetRequiredService<IXamlTypeResolver>();
        Type? inspectorExtensionType = xmlAlias is not null
            ? xamlTypeResolver.Resolve($"{xmlAlias}:{nameof(ServiceInspectorExtension)}")
            : null;

        IUriContext uriContext = serviceProvider.GetRequiredService<IUriContext>();
        Uri baseUri = uriContext.BaseUri;

        return null;
    }
}

public static class ServiceProviderExtension
{
    extension(IServiceProvider serviceProvider)
    {
        public T? GetService<T>() => (T?)serviceProvider.GetService(typeof(T));
        public T GetRequiredService<T>() => (T?)serviceProvider.GetService(typeof(T))
            ?? throw new InvalidOperationException($"Service of type {typeof(T).FullName} not found.");
    }
}
