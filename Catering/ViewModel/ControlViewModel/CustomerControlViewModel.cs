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
                CurrentModel = selectedModel.Clone();
                CurrentSituation = (int)Situation.Selected;
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
            }
        }
    }
}
