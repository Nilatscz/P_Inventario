
using Microsoft.Extensions.Logging;

namespace P_Inventario
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
            //permiso de uso camara
            builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);
            builder.Services.AddTransient<MainPage>();
            return builder.Build();

#endif

            return builder.Build();
        }
    }
}
