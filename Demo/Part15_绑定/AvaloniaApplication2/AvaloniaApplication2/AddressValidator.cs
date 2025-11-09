using System.ComponentModel.DataAnnotations;

namespace AvaloniaApplication2;

public class AddressValidator : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null) return false;
        
        //上海市 xx区xx街道
        return value.ToString().Contains("市");
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name}内容没有包含市，所以是非法数据！";
    }
}