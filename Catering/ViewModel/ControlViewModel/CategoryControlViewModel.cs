using Catering.Commands.ControlCommands.CategoryControlCommands;
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
    public class CategoryControlViewModel:BaseControlViewModel
    {
        public override string Header => "Kategoriyalar";

        private CategoryControlModel currentModel = new CategoryControlModel();
        public CategoryControlModel CurrentModel
        {
            get => currentModel;
            set
            {
                if (value == null)
                    currentModel = new CategoryControlModel();
                else
                    currentModel = value;
                OnPropertyChanged(nameof(CurrentModel));
            }
        }
        private CategoryControlModel selectedModel = new CategoryControlModel();
        public CategoryControlModel SelectedModel
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

        private List<CategoryControlModel> allCategories = new List<CategoryControlModel>();
        public List<CategoryControlModel> AllModels
        {
            get => allCategories;
            set
            {
                allCategories = value;
            }
        }

        private ObservableCollection<CategoryControlModel> categories = new ObservableCollection<CategoryControlModel>();
        public ObservableCollection<CategoryControlModel> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
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

        private void Search(string value)
        {
            var temp = AllModels.Where(x =>  x.Name.Contains(searchText) || x.Note.MyContains(searchText));
            Categories = new ObservableCollection<CategoryControlModel>(temp.ToList());
        }

        public SaveCategoryCommand Save => new SaveCategoryCommand(this);
        public RejectCategoryCommand Reject => new RejectCategoryCommand(this);
        public DeleteCategoryCommand Delete => new DeleteCategoryCommand(this);
        public ExportToExcelCustomerCommand<CategoryControlModel> ExportExcel => new ExportToExcelCustomerCommand<CategoryControlModel>(Categories);
    }
    
}
