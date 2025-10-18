using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaFieldKeyword;

public class MainViewModel : ObservableObject
{
    public string? Text
    {
        get => $"[{field}]";
        set
        {
            if (value == field) return;
            
            field = value?.Trim();
            OnPropertyChanged();
        }
    }

    public RelayCommand<string> TextUpdated { get; set; }
    
    public MainViewModel()
    {
        TextUpdated = new RelayCommand<string>(text => Text = text);
    }
}

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}