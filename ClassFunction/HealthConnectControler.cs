#if ANDROID
using Android.Content;
using Android.Content.PM;
using Android.Health.Connect;
using Android.Health.Connect.DataTypes;
using Android.Health.Connect.DataTypes.Units;
using Android.OS;
using AndroidX.Health.Connect.Client;
using AndroidX.Health.Connect.Client.Records;
using Java.Time;
using Java.Util.Concurrent;
using Microsoft.VisualBasic;
using HydrationRecord = Android.Health.Connect.DataTypes.HydrationRecord;
#endif

namespace WaterChecker.ClassFunction
{
#if ANDROID
    public class HealthConnectControler : Java.Lang.Object
    {
        private HealthConnectManager HealthConnectManager { get; set; }



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

        public async void InsertHydratacion(double Mililitres)
        {
            // creating record
            IList<Record> records = new List<HydrationRecord>
            {//new HydrationRecord.Builder( new Metadata.Builder().Build(),Instant.Now(),Instant.Now(),Volume.FromLiters(0.5)).Build()

            };

            // Executor for control operacion
            IExecutor executor = new ExecutionContext(); // Nahraďte konkrétní implementací

            // Callback for result
            IOutcomeReceiver callback = new MyOutcomeReceiver(); // Nahraďte konkrétní implementací

            // call method
            HealthConnectManager.InsertRecords(records, executor, callback);

        }
        public void GetHydratacion()
        {

        }
    }

#endif
}
