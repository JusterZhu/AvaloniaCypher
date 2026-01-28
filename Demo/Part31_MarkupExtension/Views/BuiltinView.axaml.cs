using Part31_MarkupExtension.ViewModels;

namespace Part31_MarkupExtension.Views;

public partial class BuiltinView : UserControl
{
    public BuiltinView()
    {
        InitializeComponent();
        DataContext = new BuiltinViewModel();
    }
}

