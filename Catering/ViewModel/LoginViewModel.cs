using Catering.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(Window view)
        {
            LoginCommand = new LoginCommand(this);
            View = view;
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

        public Window View { get; set; }
    }
}
