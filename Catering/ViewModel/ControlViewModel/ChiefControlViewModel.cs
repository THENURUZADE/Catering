using Catering.Commands.ControlCommands.ChiefControlCommands;
using Catering.Commands.ControlCommands.CustomerControlCommands;
using Catering.Enums;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Catering.ViewModel.ControlViewModel
{
    public class ChiefControlViewModel : BaseControlViewModel
    {
        public ChiefControlViewModel()
        {
            Save = new SaveCommand(this);
            Delete = new DeleteCommand(this);
            Reject = new RejectCommand(this);
        }
        public override string Header => "Şeflər";

        private ChiefControlModel model = new ChiefControlModel();  
        public ChiefControlModel Model
        {
            get 
            {
                if (model == null)
                {
                    model = new ChiefControlModel();
                }
                return model; 
            }
            set 
            { 
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private ChiefControlModel selectedModel;
        public ChiefControlModel SelectedModel
        {
            get 
            { 
                return selectedModel; 
            }
            set 
            { 
                selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));

                Model = selectedModel?.Clone();

                if (selectedModel != null)
                {
                    CurrentSituation = (int)Enums.Situation.Selected;
                }
            }
        }


        private List<ChiefControlModel> allChiefs;

        public List<ChiefControlModel> AllChiefs
        {
            get 
            { 
                return allChiefs; 
            }
            set 
            {
                allChiefs = value;
                OnPropertyChanged(nameof(AllChiefs));
            }
        }


        private ObservableCollection<ChiefControlModel> chiefs;
        public ObservableCollection<ChiefControlModel> Chiefs
        {
            get { return chiefs; }
            set 
            { 
                chiefs = value;
                OnPropertyChanged(nameof(Chiefs));
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set 
            { 
                searchText = value;
                Search(value);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private void Search(string searchText)
        {
            var temp = allChiefs.Where(x => x.Email.Contains(searchText) || x.Name.Contains(searchText) || x.Phone.Contains(searchText) || x.Note.MyContains(searchText));
            Chiefs = new ObservableCollection<ChiefControlModel>(temp.ToList());

        }
        public ExportToExcelCustomerCommand<ChiefControlModel> ExportExcel => new ExportToExcelCustomerCommand<ChiefControlModel>(Chiefs);

    }
    static class StringExtensions
    {
        public static bool MyContains(this string a, string txt)
        {
            if (a != null && a.Contains(txt))
            {
                return true;
            }
            return false;
        }
    }
}
