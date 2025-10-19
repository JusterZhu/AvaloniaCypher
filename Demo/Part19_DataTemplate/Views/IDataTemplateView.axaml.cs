using Avalonia.Controls;
using Part19_DataTemplate.ViewModels;

namespace Part19_DataTemplate.Views;

public partial class IDataTemplateView : UserControl
{
    public IDataTemplateView()
    {
        InitializeComponent();
        DataContext = new DataTemplatesViewModel();
    }
}