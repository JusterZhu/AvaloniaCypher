using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace AvaloniaApplication2;

public partial class MainWindow : Window
{
    private readonly Bag _viewModel;
    
    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new Bag();
        DataContext = _viewModel;
    }
    
    // 测试Default模式：修改源的UserName
    private void OnChangeUserName(object? sender, RoutedEventArgs e)
    {
        _viewModel.UserName = $"新用户名_{DateTime.Now:ss}";
    }

    // 测试OneWay模式：增加Count（源更新）
    private void OnIncreaseCount(object? sender, RoutedEventArgs e)
    {
        _viewModel.Count++;
    }

    // 测试TwoWay模式：切换IsSelected状态
    private void OnToggleIsSelected(object? sender, RoutedEventArgs e)
    {
        _viewModel.IsSelected = !_viewModel.IsSelected;
    }

    // 测试OneTime模式：修改源的InitialMessage（UI不会更新）
    private void OnChangeInitialMessage(object? sender, RoutedEventArgs e)
    {
        _viewModel.InitialMessage = $"新消息_{DateTime.Now:ss}";
    }

    // 测试OneWayToSource模式：显示源中的InputValue
    private void OnShowInputValue(object? sender, RoutedEventArgs e)
    {
        //InputValueDisplay.Text = $"源中的值：{_viewModel.InputValue}";
    }
}