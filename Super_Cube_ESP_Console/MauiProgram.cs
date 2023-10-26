using Microsoft.Extensions.Logging;
using Super_Cube_ESP_Console.executor;
using Super_Cube_ESP_Console.ViewModel;
using System.Text.RegularExpressions;

namespace Super_Cube_ESP_Console;

public static class MauiProgram
{
    public static https_handler matcher;
    public static string token;

    public static MauiApp CreateMauiApp()
    {
        // 初始化https_handler
        matcher = new https_handler();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()  
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        // AddTransient保留旧的
        builder.Services.AddSingleton<MainConsolePage>();
        builder.Services.AddSingleton<MainConsoleViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}