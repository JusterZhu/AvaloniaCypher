using Avalonia.Controls;
using Part19_DataTemplate.ViewModels;

namespace Part19_DataTemplate.Views;

public partial class DataTemplatesView : UserControl
{
    public DataTemplatesView()
    {
        InitializeComponent();
        DataContext = new DataTemplatesViewModel();
    }
}