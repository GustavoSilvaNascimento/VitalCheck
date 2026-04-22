using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using VitalCheck.Services.DataBase.Create;
using VitalCheck.Services.Navigation;
using VitalCheck.Services.Settings;
using VitalCheck.Services.Users;
using VitalCheck.View;
using VitalCheck.View.auth;


namespace VitalCheck
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("DMSans-Medium.ttf", "DMSans");
                    fonts.AddFont("DMSans-Bold.ttf", "DMSansBold");
                    fonts.AddFont("DMSans-SemiBold.ttf", "DMSansSemiBold");
                }).RegisterViewModels()
                .RegisterAppServices()
                .RegisterView(); ;

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {

            return builder;
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
            builder.Services.AddSingleton<IDataBaseService, DataBaseService>();
            return builder;
        }
        public static MauiAppBuilder RegisterView(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<DashboardView>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AlimentacaoView>();
            builder.Services.AddTransient<CadastroView>();
            builder.Services.AddTransient<IdadeView>();
            builder.Services.AddTransient<SonoView>();
            builder.Services.AddTransient<TreinoView>();
            builder.Services.AddTransient<PesoGenero>();


            return builder;
        }
    }
}
