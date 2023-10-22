namespace MauiClient;

public partial class HttpClientService
{
#if ANDROID
    public HttpClient GetPlatformSpecificHttpClient()
    {
        var httpMessageHandler = GetPlatformSpecificHttpMessageHandler();
        return new HttpClient(httpMessageHandler);
    }
   public partial HttpMessageHandler GetPlatformSpecificHttpMessageHandler();
#else
    public HttpClient GetPlatformSpecificHttpClient()
    {
        return new HttpClient();
    }

#endif
}
