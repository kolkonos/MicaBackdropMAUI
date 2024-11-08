using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace MicaBackdropMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

#if WINDOWS
            builder.ConfigureLifecycleEvents(lifecycle => {
                lifecycle.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated((window) =>
                    {
                        window.ExtendsContentIntoTitleBar = true;
                        window.SystemBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop() { Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.BaseAlt };

                        //var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        //var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                        //var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                        //switch (appWindow.Presenter)
                        //{
                        //    case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                        //        overlappedPresenter.Maximize();
                        //        break;
                        //}
                    });
                });

            });
#endif

            return builder.Build();
        }
    }
}
