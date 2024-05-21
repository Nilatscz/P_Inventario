using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;



namespace P_Inventario
{

    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]

    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode,permissions,grantResults);

            // Aquí puedes manejar los resultados de la solicitud de permisos.
            // Por ejemplo:
           /* if (requestCode == 1000) // Asegúrate de usar el requestCode que usaste al solicitar permisos
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    // Permiso concedido, realiza la operación que requiere el permiso
                }
                else
                {
                    // Permiso denegado, maneja el caso
                }
            }*/

        }
    }
}
