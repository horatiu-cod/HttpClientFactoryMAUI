using MauiClient.Services;
using Security;

namespace MauiClient.Platforms.iOS;

public class IosHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() =>
        new NSUrlSessionHandler
        {
            TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => 
                url.StartsWith("https://localhost")
        };

}
