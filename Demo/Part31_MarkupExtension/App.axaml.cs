using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Part31_MarkupExtension.ViewModels;
using Part31_MarkupExtension.Views;

namespace Part31_MarkupExtension;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDeveloperTools();
#endif
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
