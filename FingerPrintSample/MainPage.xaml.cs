using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using FingerPrintSample.Model;

namespace FingerPrintSample
{
    public partial class MainPage : ContentPage
    {
        
        private CancellationTokenSource _cancel;
        private bool _initialized;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnAuthenticate(object sender, EventArgs e)
        {
            bool value = await Retreivelocation();
            if (value)
            {
                await AuthenticationAsync("place your Finger");
            }
           
        }
        private async Task AuthenticationAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)    
        {
            _cancel = swAutoCancel.IsToggled ? new CancellationTokenSource(TimeSpan.FromSeconds(10)) : new CancellationTokenSource();
            lblStatus.Text = "";

            var dialogConfig = new AuthenticationRequestConfiguration(reason)
            { // all optional
                CancelTitle = cancel,
                FallbackTitle = fallback,
                AllowAlternativeAuthentication = swAllowAlternative.IsToggled
            };

            // optional

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig, _cancel.Token);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                await DisplayAlert("Attendance", "Success", "Ok");
                await Navigation.PushAsync(new Attend());
            }
            else
            {
                await DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
            }
        }
        private async Task<bool> Retreivelocation()
        {
            bool isGeoLocationSucsess = true;

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 2000;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000), null, true);
                if (Math.Round(position.Latitude ,1) != 15.4 && Math.Round(position.Longitude ,1)!= 75.1)
                {
                    await DisplayAlert("Not in the desired location", "failed", "ok");
                    isGeoLocationSucsess = false;
                }

                return isGeoLocationSucsess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        



    }
}