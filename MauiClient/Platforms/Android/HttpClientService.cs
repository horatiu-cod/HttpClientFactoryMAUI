using Javax.Net.Ssl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android.Net;


namespace MauiClient;

public partial class HttpClientService
{
    public partial HttpMessageHandler GetPlatformSpecificHttpMessageHandler()
    {
       var androidHttpHandler = new AndroidMessageHandler
       {
           ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
           {
               if(certificate.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None)
                    return true;
               return false;
           }
       };
        return androidHttpHandler;
    }

    class LocalHostNameVerifier : Java.Lang.Object, IHostnameVerifier
    {
        public bool Verify(string hostname, ISSLSession session)
        {
            
            if (HttpsURLConnection.DefaultHostnameVerifier.Verify(hostname, session) ||hostname == "10.0.2.2")
            {
                return true;
            }
            return false;
        }
    }

}
