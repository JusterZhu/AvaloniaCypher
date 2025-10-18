using System.Collections.Generic;

namespace Part19_DataTemplate.Models;

public class Person
{
    public string? Name { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        return $"姓名：{Name} - 年龄：{Age}";
    }
}

public class Teacher : Person
{
    public string? Subject { get; set; }
}

public class Student : Person
{
    public int Grade { get; set; }
    public IEnumerable<string> Lessons { get; set; } = [];
}