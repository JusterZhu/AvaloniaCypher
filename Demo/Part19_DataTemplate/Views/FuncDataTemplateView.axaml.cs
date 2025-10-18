using Avalonia.Controls;
using Part19_DataTemplate.ViewModels;

namespace Part19_DataTemplate.Views;

public partial class FuncDataTemplateView : UserControl
{
    public FuncDataTemplateView()
    {
        InitializeComponent();
        DataContext = new DataTemplatesViewModel();
    }
}