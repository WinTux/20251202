using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;

namespace EjemplosVarios
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiMaps()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.UseBarcodeReader(); // Configura el uso del lector de códigos de barras
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<Pages.RelojPage>();
            builder.Services.AddTransient<Pages.TrazosPage>();
            builder.Services.AddTransient<Pages.MapasPage>();
            builder.Services.AddTransient<Pages.VideosPage>();
            builder.Services.AddTransient<Pages.GridPage>();
            builder.Services.AddTransient<Pages.Grid2Page>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
