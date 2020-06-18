using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChatApp.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnLogin.Clicked += BtnLogin_Clicked;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var userName = txtLogin.Text;
            if (string.IsNullOrEmpty(userName))
            {
                await DisplayAlert("Validation errors", "The UserName is required", "Ok");
                return;
            }

            await Navigation.PushAsync(new ChatPage(userName));
        }
    }
}