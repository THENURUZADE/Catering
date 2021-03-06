using PrivateCatering.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrivateCatering.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }
        public string Username { get; set; }
        public LoginCommand LoginCommand { get; }
        private Visibility visibilityIncorrectPassword = Visibility.Collapsed;
        public Visibility VisibilityIncorrectPassword
        {
            get => visibilityIncorrectPassword;
            set
            {
                visibilityIncorrectPassword = value;
                OnPropertyChanged(nameof(VisibilityIncorrectPassword));
            }
        }
    }
}
