using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Enums;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class SaveCustomerCommand : BaseControlCommand<CustomerControlViewModel>
    {
        public SaveCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            if(viewModel.CurrentSituation == (int)Situation.Normal)
            {
                viewModel.CurrentSituation = (int)Situation.Add;
            }
            else if(viewModel.CurrentSituation == (int)Situation.Selected)
            {
                viewModel.CurrentSituation = (int)Situation.Edit;
            }
            else
            {
                CustomerMapper mapper = new CustomerMapper();
                Customer customer = mapper.Map(viewModel.CurrentModel);
                customer.Creator = Kernel.CurrentUser;
                customer.LastModifiedDate = DateTime.Now;

                if (viewModel.CurrentModel.IsValid())
                {
                    if (viewModel.CurrentSituation == (int)Situation.Add)
                    {
                        int id = DB.CustomerRepository.Add(customer);
                        viewModel.CurrentModel.Id = id;
                        viewModel.CurrentModel.No = viewModel.AllModels.Count + 1;

                        viewModel.AllModels.Add(viewModel.CurrentModel);
                        viewModel.Customers.Add(viewModel.CurrentModel.Clone());

                        viewModel.CurrentModel = new CustomerControlModel();
                        viewModel.CurrentSituation = (int)Situation.Normal;

                        if (id != default(int))
                        {
                            MessageBox.Show(UIMessages.SuccessedMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    else if (viewModel.CurrentSituation == (int)Situation.Edit)
                    {
                        if (DB.CustomerRepository.Update(customer))
                        {
                            int no = viewModel.CurrentModel.No - 1;

                            CustomerControlModel model = viewModel.AllModels.FirstOrDefault(x => x.Id == viewModel.SelectedModel.Id);

                            int index = viewModel.AllModels.IndexOf(model);
                            viewModel.AllModels[index] = viewModel.CurrentModel.Clone();
                            viewModel.Customers[no] = viewModel.CurrentModel;

                            viewModel.CurrentModel = new CustomerControlModel();
                            viewModel.SelectedModel = null;

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
    }
}
