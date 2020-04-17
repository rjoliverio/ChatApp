using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        MainPage mpage;
        
        public SignUp()
        {
            InitializeComponent();
        }
        public SignUp(MainPage mp)
        {
            mpage = mp;
            
            InitializeComponent();
        }
        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Sign up successful. Verification Email Sent", "Okay");
            Navigation.PopModalAsync();
        }

        async private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Sign up successful. Verification Email Sent", "Okay");
            Navigation.PopModalAsync();
        }

        async private void CustomButton_Clicked(object sender, EventArgs e)
        {
            if (usernameEntry.Text != "" && emailSUEntry.Text != "" && pass1SUEntry.Text != "" && pass2SUEntry.Text != "")
            {
                if(pass1SUEntry.Text== pass2SUEntry.Text)
                {
                     Account account =new Account(usernameEntry.Text,emailSUEntry.Text,pass1SUEntry.Text);
                    mpage.getAccount(account);
                    ai.IsRunning = true;
                    aiLayout.BackgroundColor = Color.FromRgba(0, 0, 0, 0.50);
                    aiLayout.IsVisible = true;
                    await Task.Delay(2000);
                    aiLayout.IsVisible = false;
                    ai.IsRunning = false;
                    await DisplayAlert("Success", "Sign up successful. Verification Email Sent", "Okay");
                    await Navigation.PopModalAsync();
                    
                }
                else
                {
                    await DisplayAlert("Error", "Password don't match", "Okay");
                }
            }
            else
            {
                if (usernameEntry.Text == "")
                {
                    usernameEntry.BorderColor = Color.Red;
                }
                if (emailSUEntry.Text == "")
                {
                    emailSUEntry.BorderColor = Color.Red;
                }
                if (pass1SUEntry.Text == "")
                {
                    pass1SUEntry.BorderColor = Color.Red;
                }
                if (pass2SUEntry.Text == "")
                {
                    pass2SUEntry.BorderColor = Color.Red;
                }
                await DisplayAlert("Error", "Missing Fields", "Okay");
            }
        }

        private void SUEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var elem = (CustomEntry)sender;
            elem.BorderColor = Color.Black;
        }

        private void pass1_Clicked(object sender, EventArgs e)
        {
            if(pass1.Text=="Show" && pass2.Text == "Show")
            {
                pass1.Text = "Hide";
                pass1SUEntry.IsPassword = false;
                pass2.Text = "Hide";
                pass2SUEntry.IsPassword = false;
            }
            else
            {
                pass1.Text = "Show";
                pass1SUEntry.IsPassword = true;
                pass2.Text = "Show";
                pass2SUEntry.IsPassword = true;
            }
                
        }

        private void CustomButton_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}