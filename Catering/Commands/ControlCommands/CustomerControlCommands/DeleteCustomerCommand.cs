using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Enums;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel.Helper;
using Catering.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            sureDialogBox.ShowDialog();

            if(sureDialogBox.DialogResult == true)
            {
                CustomerMapper mapper = new CustomerMapper();
                Customer customer = mapper.Map(viewModel.CurrentModel);
                customer.Creator = Kernel.CurrentUser;
                customer.LastModifiedDate = DateTime.Now;
                customer.IsDeleted = true;

                if (DB.CustomerRepository.Update(customer))
                {
                    int no = viewModel.SelectedModel.No - 1;

                    CustomerControlModel model = viewModel.AllModels.FirstOrDefault(x => x.Id == viewModel.SelectedModel.Id);
                    viewModel.AllModels.Remove(model);
                    CollectionNumerator<CustomerControlModel>.Numerate(viewModel.AllModels, model.No - 1);
                    viewModel.Customers = new ObservableCollection<CustomerControlModel>(viewModel.AllModels);


                    viewModel.SelectedModel = null;
                    viewModel.CurrentModel = new CustomerControlModel();
                    viewModel.CurrentSituation = (int)Situation.Normal;

                    MessageBox.Show(UIMessages.SuccessedMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }


        }
    }
}
