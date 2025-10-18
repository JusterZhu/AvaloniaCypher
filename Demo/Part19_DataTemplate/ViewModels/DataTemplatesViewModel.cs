using System.Collections.Generic;
using Part19_DataTemplate.Models;

namespace Part19_DataTemplate.ViewModels;

public partial class DataTemplatesViewModel : ViewModelBase
{
    public IEnumerable<Person> People { get; set; } =
    [
        new Person { Name = "路人甲", Age = 30 },
        new Person { Name = "路人乙", Age = 25 },
        new Person { Name = "路人丙", Age = 14 },
        new Teacher { Name = "李老师", Age = 35, Subject = "语文" },
        new Teacher { Name = "王老师", Age = 40, Subject = "数学" },
        new Teacher { Name = "张老师", Age = 30, Subject = "英语" },
        new Student { Name = "张三", Age = 7, Grade = 1 },
        new Student { Name = "李四", Age = 10, Grade = 4 },
        new Student { Name = "王五", Age = 13, Grade = 7 },
    ];
}