using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Object logged,email,pass,uname;
            if (Application.Current.Properties.TryGetValue("logged", out logged))
            {
                Application.Current.Properties.TryGetValue("email", out email);
                Application.Current.Properties.TryGetValue("pass", out pass);
                Application.Current.Properties.TryGetValue("uname", out uname);
                Account acc = new Account((string)uname, (string)email, (string)pass);
               MainPage = new NavigationPage(new UserTabbedPage { BindingContext = acc });
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
            
        }

        protected override void OnSleep()
        {
           
        }

        protected override void OnResume()
        {
            
        }


    }
}
