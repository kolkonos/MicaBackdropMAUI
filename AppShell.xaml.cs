using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
#if WINDOWS
using Microsoft.UI.Xaml.Controls;
#endif

namespace MicaBackdropMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        this.Loaded += (_, _) => {
            OverrideBg();
        };
    }

    internal void OverrideBg()
    {
#if WINDOWS        
        var shellView = Shell.Current?.Handler?.PlatformView as ShellView;
        var navigationView = shellView?.Content as MauiNavigationView;

        var contentGrid = navigationView?
            .GetType()
            .GetProperty("ContentGrid", 
            System.Reflection.BindingFlags.NonPublic | 
                      System.Reflection.BindingFlags.Instance)?
            .GetValue(navigationView) as Microsoft.UI.Xaml.Controls.Grid;

        contentGrid!.Background.Opacity = 0;
#endif
    }
}