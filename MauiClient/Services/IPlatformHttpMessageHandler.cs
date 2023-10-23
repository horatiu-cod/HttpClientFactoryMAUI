namespace MauiClient.Services;

public interface IPlatformHttpMessageHandler
{
    HttpMessageHandler GetHttpMessageHandler();
}
