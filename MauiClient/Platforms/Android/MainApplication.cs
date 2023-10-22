using Android.App;
using Android.Runtime;

namespace MauiClient
{
    // add UsesCleartextTraffic property and ste it to true, USE ONLY for developement
#if DEBUG
    [Application(UsesCleartextTraffic = true)]
#else
    [Application]
#endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}