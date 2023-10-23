using MauiClient.Services;
using System.Net.Security;
using Xamarin.Android.Net;

namespace MauiClient.Platforms.Android
{
    public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() => new AndroidMessageHandler
        {
            ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) => (certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None)
        };
    }
}
