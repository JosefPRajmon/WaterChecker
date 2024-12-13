#if ANDROID
using WaterChecker.Platforms.Android;
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
            HealthConnectImplementationcall.AddWaterIntake(100);
#endif

        }
    }

}
