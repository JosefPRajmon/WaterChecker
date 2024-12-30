#if ANDROID
using Android.Content;
using Android.Content.PM;
using Android.Health.Connect;
using Android.Health.Connect.DataTypes;
using Android.Health.Connect.DataTypes.Units;
using AndroidX.Health.Connect.Client;
using AndroidX.Health.Connect.Client.Records;
using Microsoft.VisualBasic;
#endif

namespace WaterChecker.ClassFunction
{
#if ANDROID
    public class HealthConnectControler
    {
        public async void GetPermision()
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(28))
            {


                try
                {
                    var activity = Platform.CurrentActivity;

                    // Správný intent pro Health Connect permissions

                    try
                    {
                        var intent = new Intent("androidx.health.ACTION_HEALTH_CONNECT_SETTINGS");
                        // Spuštění aktivity pro získání permissions
                        activity.StartActivity(intent);
                    }
                    catch (ActivityNotFoundException ex)
                    {
                        // Health Connect není nainstalován
                        // Můžeme uživatele přesměrovat do Google Play Store
                        var playStoreIntent = new Intent(Intent.ActionView);
                        playStoreIntent.SetData(Android.Net.Uri.Parse("market://details?id=com.google.android.apps.healthdata"));
                        activity.StartActivity(playStoreIntent);
                    }
                }
                catch (Exception)
                {
                }

            }
        }
    }
#endif
}
