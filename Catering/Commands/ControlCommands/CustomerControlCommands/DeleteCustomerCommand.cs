using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel.Helper;
using Catering.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class DeleteCustomerCommand : BaseCustomerCommand
    {
        public DeleteCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            SureDialogBox sureDialogBox = new SureDialogBox();
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel(sureDialogBox);
            sureDialogBox.DataContext = sureDialogViewModel;

            if(sureDialogBox.DialogResult == true)
            {

            }


        }
    }
}
