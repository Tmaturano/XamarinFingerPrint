using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Xamarin.Forms;

namespace XamarinFingerPrint
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Touch in the sensor");
                if (auth.Authenticated)
                {
                    Result.Text = "Authenticated successfully";
                }
                else
                {
                    Result.Text = "Fingerprint not detected";
                }
            }
            else
            {
                await DisplayAlert("Alert", "Your device does not support fingerprint detection", "Ok");
            }
        }
    }
}
