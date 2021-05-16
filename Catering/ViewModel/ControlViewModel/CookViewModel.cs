using Catering.Commands.ControlCommands.CookControlCommands;
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
    public class CookViewModel : BaseControlViewModel
    {
        public override string Header => "Yeməklər";

        private CookModel currentModel = new CookModel();
        public CookModel CurrentModel
        {
            get => currentModel;
            set
            {
                currentModel = value;
                OnPropertyChanged(nameof(CurrentModel));
            }
        }

        private CookModel selectedModel = new CookModel();
        public CookModel SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                if (value != null)
                {
                    CurrentModel = selectedModel?.Clone();
                    CurrentSituation = (int)Situation.Selected;
                }
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        public List<CookModel> AllModels { get; set; }

        private ObservableCollection<CookModel> cooks;
        public ObservableCollection<CookModel> Cooks
        {
            get => cooks;
            set
            {
                cooks = value;
                OnPropertyChanged(nameof(Cooks));
            }
        }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search(searchText);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public List<CategoryControlModel> Categories { get; set; }

        #region Commands
        public SaveCookCommand Save => new SaveCookCommand(this);
        public RejectCookCommand Reject => new RejectCookCommand(this);
        public DeleteCookCommand Delete => new DeleteCookCommand(this);
        public ExportToExcelCustomerCommand<CookModel> ExportExcel => new ExportToExcelCustomerCommand<CookModel>( Cooks);
        #endregion

        #region Commands
        private void Search(string searchText)
        {
            List<CookModel> resultModels = new List<CookModel>();
            foreach (var item in AllModels)
            {
                if (item.Name.Contains(searchText) || item.No.ToString().Contains(searchText) ||
                    IsNoteContains(item.Note, searchText) || item.Category.Name.ToString().Contains(searchText)||
                    item.PortionPrice.ToString().Contains(searchText) || item.PortionWeight.ToString().Contains(searchText))
                {
                    resultModels.Add(item);
                }
            }
            Cooks = new ObservableCollection<CookModel>(resultModels);
        }

        private bool IsNoteContains(string note, string searchText)
        {
            if (note != null && note.Contains(searchText))
                return true;
            return false;
        }
        #endregion
    }
}
