using Part31_MarkupExtension.ViewModels;

namespace Part31_MarkupExtension.Views;

public partial class CustomView : UserControl
{
    public CustomView()
    {
        InitializeComponent();
        DataContext = new CustomViewModel();
    }
}

