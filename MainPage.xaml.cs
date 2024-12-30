#if ANDROID
using WaterChecker.ClassFunction;
#endif
namespace WaterChecker
{
    public partial class MainPage : ContentPage
    {
#if ANDROID
        HealthConnectControler HealthConnectControler = new HealthConnectControler();
#endif
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
            HealthConnectControler.GetPermision();
#endif
        }
    }

}
