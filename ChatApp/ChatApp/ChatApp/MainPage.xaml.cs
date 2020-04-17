using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ChatApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Account acc=new Account();
        public MainPage()
        {
            InitializeComponent();
            
            
        }
        public MainPage( Account ac)
        {
            acc = ac;
            InitializeComponent();
        }
        async private void CustomButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUp (this));
        }


        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ai.IsRunning = true;
            aiLayout.BackgroundColor = Color.FromRgba(0, 0, 0, 0.50);
            aiLayout.IsVisible = true;
            await Task.Delay(2000);
            aiLayout.IsVisible = false;
            ai.IsRunning = false;
            acc.Logged = true;
            Application.Current.Properties.Clear();
            Application.Current.Properties.Add("logged", acc.Logged);
            Application.Current.Properties.Add("email", acc.Email);
            Application.Current.Properties.Add("pass", acc.Password);
            Application.Current.Properties.Add("uname", acc.UserName);
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new UserTabbedPage{ BindingContext = acc };
        }

        private void passShow_Clicked(object sender, EventArgs e)
        {
            if (passShow.Text == "Show")
            {
                passShow.Text = "Hide";
                passEntry.IsPassword = false;
            }
            else
            {
                passShow.Text = "Show";
                passEntry.IsPassword = true;
            }
        }

        async private void btnSignIn_Clicked(object sender, EventArgs e)
        {
            if (emailEntry.Text=="" || passEntry.Text=="")
            {
                if (emailEntry.Text == "")
                {
                    emailEntry.BorderColor = Color.Red;
                }
                if (passEntry.Text == "")
                {
                    passEntry.BorderColor = Color.Red;
                }
               await DisplayAlert("Error", "Missing Fields", "Okay");
            }
            else
            {
                
                if(emailEntry.Text==acc.Email && passEntry.Text == acc.Password)
                {
                    ai.IsRunning = true;
                    aiLayout.BackgroundColor = Color.FromRgba(0, 0, 0, 0.50);
                    aiLayout.IsVisible = true;
                    await Task.Delay(2000);
                    aiLayout.IsVisible = false;
                    ai.IsRunning = false;
                    acc.Logged = true;
                    Application.Current.Properties.Clear();
                    Application.Current.Properties.Add("logged", acc.Logged);
                    Application.Current.Properties.Add("email", acc.Email);
                    Application.Current.Properties.Add("pass", acc.Password);
                    Application.Current.Properties.Add("uname", acc.UserName);
                    await Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new UserTabbedPage {BindingContext=acc};
                }
                else
                {
                    await DisplayAlert("Error", "Account doesn't exist", "Okay");
                }
                
            }
            
        }
        private void passEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            passEntry.BorderColor = Color.Black;
        }

        private void emailEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailEntry.BorderColor = Color.Black;
        }
        public void getAccount(Account ac)
        {
            acc = ac;
        }

    }
    
}
