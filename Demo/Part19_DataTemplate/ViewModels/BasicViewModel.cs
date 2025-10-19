using System.Collections.Generic;
using Part19_DataTemplate.Models;

namespace Part19_DataTemplate.ViewModels;

public partial class BasicViewModel : ViewModelBase
{
    public Person Person { get; set; } = new() { Name = "路人甲", Age = 30 };

    public IEnumerable<Teacher> Teachers { get; set; } =
    [
        new() { Name = "李老师", Age = 35, Subject = "语文" },
        new() { Name = "王老师", Age = 40, Subject = "数学" },
        new() { Name = "张老师", Age = 30, Subject = "英语" },
    ];

    public IEnumerable<Student> Students { get; set; } =
    [
        new() { Name = "张三", Age = 7, Grade = 1, Lessons = ["语文", "数学"] },
        new() { Name = "李四", Age = 10, Grade = 4, Lessons = ["语文", "数学", "英语"] },
        new() { Name = "王五", Age = 13, Grade = 7, Lessons = ["语文", "数学", "英语"] },
    ];
}