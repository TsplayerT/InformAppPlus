using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.OneSignal;
using Firebase;
using InformAppPlus.Controle;
using InformAppPlus.Utilidade;
using Plugin.CurrentActivity;
using Plugin.Media;
using Plugin.Permissions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;

namespace InformAppPlus.Droid
{
    [Activity(Label = "InformAppPlus", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Parallel.Invoke(() =>
            {
                Platform.Init(this, savedInstanceState);
                Forms.Init(this, savedInstanceState);
                LoadApplication(new Principal());
            },
            () =>
            {
                FirebaseApp.InitializeApp(this);
                OneSignal.Current.StartInit(Constantes.AppId).EndInit();
            }, async () =>
            {
                CrossCurrentActivity.Current.Init(this, savedInstanceState);
                await CrossMedia.Current.Initialize();
            });
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}