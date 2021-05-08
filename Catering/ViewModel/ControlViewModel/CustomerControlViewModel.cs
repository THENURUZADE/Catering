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

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search(value);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        #region Commands

        public SaveCustomerCommand Save => new SaveCustomerCommand(this);
        public RejectCustomerCommand Reject => new RejectCustomerCommand(this);
        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);
        public ExportToExcelCustomerCommand<CustomerControlModel, CustomerControlViewModel> ExportExcel => new ExportToExcelCustomerCommand<CustomerControlModel,CustomerControlViewModel>(this,Customers);

        #endregion

        #region Methods

        private void Search(string searchText)
        {
            List<CustomerControlModel> resultModels = new List<CustomerControlModel>();
            foreach (var item in AllModels)
            {
                if(item.Name.Contains(searchText) || item.No.ToString().Contains(searchText) ||
                    IsNoteContains(item.Note, searchText) || item.Phone.ToString().Contains(searchText) || 
                    item.Address.Contains(searchText) || IsEmailContains(item.Email, searchText))
                {
                    resultModels.Add(item);
                }
            }
            Customers = new ObservableCollection<CustomerControlModel>(resultModels);
        }

        private bool IsNoteContains(string note, string searchText)
        {
            if (note != null && note.Contains(searchText))
                return true;
            return false;
        }
        private bool IsEmailContains(string email, string searchText)
        {
            if (email != null && email.Contains(searchText))
                return true;
            return false;
        }

        #endregion
    }
}
