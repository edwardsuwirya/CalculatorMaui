using CalcMaui.Data.Local;
using CalcMaui.Domain.Repository;
using CalcMaui.Presentation.Navigation;
using CalcMaui.Presentation.Pages;
using CalcMaui.Presentation.ViewModels;
using Microsoft.Extensions.Logging;

namespace CalcMaui;

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
            })
            .RegisterRepositories()
            .RegisterNavigation()
            .RegisterViewModels()
            .RegisterViews();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ICalcRepository, CalcRepository>();
        return builder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<CalcViewModel>();
        return builder;
    }

    private static MauiAppBuilder RegisterNavigation(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppNavigation, AppNavigation>();
        return builder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<CalcPage>();
        builder.Services.AddSingleton<LoadingPage>();
        return builder;
    }
}