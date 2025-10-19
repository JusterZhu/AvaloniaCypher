using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Layout;
using Part19_DataTemplate.Models;

namespace Part19_DataTemplate.DataTemplates;

public static class FuncDataTemplateProvider
{
    public static IDataTemplate CommonFuncDataTemplate =>
        new FuncDataTemplate(
            obj => obj is Person,
            (obj, _) =>
            {
                return obj switch
                {
                    Teacher teacher => TeacherFuncDataTemplate.Build(teacher),
                    Student student => StudentFuncDataTemplate.Build(student),
                    Person person => PersonFuncDataTemplate.Build(person),
                    _ => null
                };
            });

    public static IDataTemplate CommonFuncDataTemplate2 =>
        new FuncDataTemplate<Person>((obj, _) =>
        {
            return obj switch
            {
                Teacher teacher => TeacherFuncDataTemplate.Build(teacher),
                Student student => StudentFuncDataTemplate.Build(student),
                Person person => PersonFuncDataTemplate.Build(person),
                _ => null
            };
        });

    public static IDataTemplate PersonFuncDataTemplate =>
        new FuncDataTemplate(
            match: person => person is Person,
            build: (person, _) =>
            {
                if (person is not Person p) return null;
                return new UniformGrid
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Columns = 2,
                    Children =
                    {
                        new TextBlock { Text = "姓名 ：" },
                        new TextBlock
                        {
                            [!TextBlock.TextProperty] = new Binding(nameof(p.Name))
                        },
                        new TextBlock { Text = "年龄：" },
                        new TextBlock
                        {
                            [!TextBlock.TextProperty] = new Binding(nameof(p.Age))
                        },
                    }
                };
            },
            supportsRecycling: false);

    public static IDataTemplate TeacherFuncDataTemplate =>
        new FuncDataTemplate<Teacher>(
            teacher => teacher is Teacher,
            (teacher, _) =>
                new StackPanel
                {
                    Children =
                    {
                        new TextBlock { Text = $"老师：{teacher.Name}" },
                        new TextBlock { Text = $"年龄：{teacher.Age}" },
                        new TextBlock { Text = $"教学：{teacher.Subject}" }
                    }
                });

    public static IDataTemplate StudentFuncDataTemplate =>
        new FuncDataTemplate<Student>((student, _) =>
            new StackPanel
            {
                Children =
                {
                    new TextBlock { Text = $"学生：{student.Name}" },
                    new TextBlock { Text = $"年龄：{student.Age}" },
                    new TextBlock { Text = $"年级：{student.Grade}" }
                }
            });
}