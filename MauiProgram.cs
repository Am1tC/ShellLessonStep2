using Microsoft.Extensions.Logging;
using ShellLessonStep2.Services;
using ShellLessonStep2.ViewModels;
using ShellLessonStep2.Views;

namespace ShellLessonStep2;

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

        return builder.Build();
    }
    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        //--------singleton Pages
        builder.Services.AddSingleton<Cats>();
        builder.Services.AddSingleton<Dogs>();
        builder.Services.AddSingleton<Monkey>();
        builder.Services.AddSingleton<Elephants>();
        builder.Services.AddSingleton<Bears>();

        //--------Transient pages

        builder.Services.AddTransient<AnimalDetailsView>();

        return builder;
    }

    public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AnimalService>();
        return builder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<CatsViewModel>();
        builder.Services.AddSingleton<DogsViewModel>();
        builder.Services.AddSingleton<MonkeysViewModel>();
        builder.Services.AddSingleton<ElephantsViewModel>();
        builder.Services.AddSingleton<BearsViewModel>();

        //--------Transient ViewModels
        builder.Services.AddTransient<AnimalDetailsViewModel>();

        return builder;


    }
}
