using Microsoft.Extensions.Logging;
using VitalCheck.Data.SqLite;
using VitalCheck.Services;

namespace VitalCheck
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "vitalcheck.db3");

            builder.Services.AddSingleton(new SqLiteDataBase(dbPath));

            builder.Services.AddSingleton<UsuarioService>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("DMSans-Medium.ttf", "DMSans");
                    fonts.AddFont("DMSans-Bold.ttf", "DMSansBold");
                    fonts.AddFont("DMSans-SemiBold.ttf", "DMSansSemiBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
