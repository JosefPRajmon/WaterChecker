using Android.Content;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Application = Android.App.Application;
namespace WaterChecker.Platforms.Android
{


    public class HealthConnectImplementationcall
    {
        public static void AddWaterIntake(double volumeInMilliliters)
        {
            var context = Application.Context;
            var manager = new HealthConnectManager(context);
            manager.AddWaterIntake(volumeInMilliliters);
        }
    }

    public class HealthConnectManager
    {
        private readonly Context _context;
        public HealthConnectManager(Context context)
        {
            _context = context;
        }

        public void AddWaterIntake(double volumeInMilliliters)
        {

            if (ContextCompat.CheckSelfPermission(_context, "android.permission.ACCESS_HEALTH_DATA") != Permission.Granted)
            {
                var _activity = Platform.CurrentActivity; // Získá aktuální aktivitu

                ActivityCompat.RequestPermissions(_activity, new string[] { "android.permission.ACCESS_HEALTH_DATA" }, 100);
            }
            try
            {
                var healthConnectIntent = new Intent("com.google.android.healthconnect.ACTION_WRITE_DATA");
                healthConnectIntent.PutExtra("volume", volumeInMilliliters);

                // Add the FLAG_ACTIVITY_NEW_TASK flag to the intent
                healthConnectIntent.SetFlags(ActivityFlags.NewTask);

                // Start the activity with the modified intent
                _context.StartActivity(healthConnectIntent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}