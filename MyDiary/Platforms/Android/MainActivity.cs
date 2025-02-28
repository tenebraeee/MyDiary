using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MyDiary
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
