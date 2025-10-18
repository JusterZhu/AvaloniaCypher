using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace Part19_DataTemplate.DataTemplates;

public class DictionaryDataTemplate : ResourceDictionary, IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null) return null;
        var type = param.GetType();
        if (TryGetResource(type, null, out var template)
            && template is IDataTemplate dt)
        {
            return dt.Build(param);
        }

        return null;
    }

    public bool Match(object? data)
    {
        return data is not null && ContainsKey(data.GetType());
    }
}