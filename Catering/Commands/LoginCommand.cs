﻿using Catering.Core.Domain.Entities;
using Catering.Core.Security;
using Catering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Catering.Commands
{
    public class LoginCommand : BaseCommand
    {
        public readonly LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            User user = DB.UserRepository.Get(viewModel.Username);
            PasswordBox psBox = (PasswordBox)parameter;
            if (user != null)
            {
                if (MySecurityHelper.ComputeSha256Hash(psBox.Password) == user.Password)
                {
                    //Correct
                }
                else
                {
                    viewModel.VisibilityIncorrectPassword = Visibility.Visible;
                }
            }
            else
            {
                viewModel.VisibilityIncorrectPassword = Visibility.Visible;
            }
        }
    }
}
