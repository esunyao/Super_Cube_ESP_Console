using Android.App;
using Android.Runtime;
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]

namespace Super_Cube_ESP_Console;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}