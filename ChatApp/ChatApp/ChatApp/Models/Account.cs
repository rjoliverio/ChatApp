using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatApp
{
    public class Account : INotifyPropertyChanged
    {
        private string MyUserName;
        private string MyEmail;
        private string MyPassword;
        private bool IsLogged;
        public string UserName { get {return MyUserName; } set { MyUserName= value; OnPropertyChanged(nameof(UserName)); } }
        public string Email { get { return MyEmail; } set { MyEmail = value; OnPropertyChanged(nameof(Email)); } }
        public string Password { get { return MyPassword; } set { MyPassword = value; OnPropertyChanged(nameof(Password)); } }
        
        public bool Logged { get { return IsLogged; } set { IsLogged = value; OnPropertyChanged(nameof(Logged)); } }
        public Account()
        {
            this.UserName = "Rj Oliverio";
            this.Email = "rjoliverio@gmail.com";
            this.Password = "123";
            this.Logged = false;
        }
        public Account(string un,string email, string pass)
        {
            this.UserName = un;
            this.Email = email;
            this.Password = pass;
            this.Logged = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
