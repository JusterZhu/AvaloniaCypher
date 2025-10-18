using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Part19_DataTemplate.Models;

namespace Part19_DataTemplate.DataTemplates;

public class CommonDataTemplate : IDataTemplate
{
    public IDataTemplate? PersonDataTemplate { get; set; }
    public IDataTemplate? TeacherDataTemplate { get; set; }
    public IDataTemplate? StudentDataTemplate { get; set; }

    public Control? Build(object? param)
    {
        if (param is null) return null;
        return param switch
        {
            Teacher => TeacherDataTemplate?.Build(param),
            Student => StudentDataTemplate?.Build(param),
            Person => PersonDataTemplate?.Build(param),
            _ => null
        };
    }

    public bool Match(object? data)
    {
        return data is Person;
    }
}