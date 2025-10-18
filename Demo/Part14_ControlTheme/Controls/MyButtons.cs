using System;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Part14_ControlTheme.Controls;

public class MyButton1 : ContentControl
{
}

public class MyButton2 : ContentControl
{
    protected override Type StyleKeyOverride => typeof(Button);
}

public class MyButton3 : ContentControl, IStyleable
{
    //写法过时了，Avalonia 12.0版本会移除
    Type IStyleable.StyleKey => typeof(Button);
}