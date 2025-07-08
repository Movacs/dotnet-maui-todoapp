using Microsoft.Extensions.Logging;
using TodoAppMaui.Services;
using TodoAppMaui.ViewModels;
using TodoAppMaui.Views;

namespace TodoAppMaui
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

            builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<AddTodoPage>();
            builder.Services.AddTransient<TodoViewModel>();
            builder.Services.AddTransient<AddTodoViewModel>();
            builder.Services.AddSingleton<TodoApiService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
