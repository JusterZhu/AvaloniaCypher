using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;

namespace Part19_DataTemplate.DataTemplates;

public class DataTemplateSelector : IDataTemplate
{
    [Content] public AvaloniaList<IDataTemplate> DataTemplates { get; } = [];

    public Control? Build(object? param)
    {
        foreach (var dt in DataTemplates)
        {
            if (dt.Match(param))
            {
                return dt.Build(param);
            }
        }

        return null;
    }

    public bool Match(object? data)
    {
        foreach (var dt in DataTemplates)
        {
            if (dt.Match(data)) return true;
        }

        return false;
    }
}