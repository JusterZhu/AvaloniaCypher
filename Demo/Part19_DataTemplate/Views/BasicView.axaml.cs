using Avalonia.Controls;
using Part19_DataTemplate.ViewModels;

namespace Part19_DataTemplate.Views;

public partial class BasicView : UserControl
{
    public BasicView()
    {
        InitializeComponent();
        DataContext = new BasicViewModel();
    }
}