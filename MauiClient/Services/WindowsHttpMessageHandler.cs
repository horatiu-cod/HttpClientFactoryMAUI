
namespace MauiClient.Services;

public class WindowsHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler()
    {
        return new HttpClientHandler();
    }
}
