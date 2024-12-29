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
namespace WaterChecker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
#if ANDROID

#endif
        }

        private async void HealthConnectPermision_Button(object sender, EventArgs e)
        {
#if ANDROID
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
#endif
        }
    }

}
