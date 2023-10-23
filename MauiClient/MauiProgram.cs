using MauiClient.Services;
using Microsoft.Extensions.Logging;

namespace MauiClient
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
            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(_ =>
            {
#if ANDROID
                return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
                return new Platforms.iOS.IosHttpMessageHandler();
#else
                return new WindowsHttpMessageHandler();
#endif
            });
#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient("maui-to-api", httpClient =>
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7152" : "https://localhost:7152";
                httpClient.BaseAddress = new Uri(baseUrl);
            })
                .ConfigureHttpMessageHandlerBuilder(messageBuilder =>
                {
                    var platformHttpMessageHandler =
                        messageBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                    messageBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
                });

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}