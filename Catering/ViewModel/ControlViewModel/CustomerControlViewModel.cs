using Catering.Commands.ControlCommands.CustomerControlCommands;
using Catering.Enums;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.ViewModel.ControlViewModel
{
    public class CustomerControlViewModel : BaseControlViewModel
    {
        public override string Header => "Müştərilər";

        private CustomerControlModel currentModel = new CustomerControlModel();
        public CustomerControlModel CurrentModel
        {
            get => currentModel;
            set
            {
                currentModel = value;
                OnPropertyChanged(nameof(CurrentModel));
            }
        }
        private CustomerControlModel selectedModel = new CustomerControlModel();
        public CustomerControlModel SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                if (selectedModel != null)
                {
                    CurrentModel = selectedModel.Clone();
                    CurrentSituation = (int)Situation.Selected;
                }
                OnPropertyChanged(nameof(SelectedModel));
            }
        }
        
        private List<CustomerControlModel> allCustomers = new List<CustomerControlModel>();
        public List<CustomerControlModel> AllModels
        {
            get => allCustomers;
            set
            {
                allCustomers = value;
            }
        }

        private ObservableCollection<CustomerControlModel> customers = new ObservableCollection<CustomerControlModel>();
        public ObservableCollection<CustomerControlModel> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }


        public SaveCustomerCommand Save => new SaveCustomerCommand(this);
        public RejectCustomerCommand Reject => new RejectCustomerCommand(this);
        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);
    }
}
