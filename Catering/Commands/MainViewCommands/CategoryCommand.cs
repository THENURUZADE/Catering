using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel;
using Catering.Views.UserControls;
using Catering.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.MainViewCommands
{
    public class CategoryCommand : BaseCommand
    {
        private MainViewModel viewModel;
        public CategoryCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            CategoryControl categoryControl = new CategoryControl();
            CategoryControlViewModel categoryViewModel = new CategoryControlViewModel();
            categoryControl.DataContext = categoryViewModel;


            CategoryMapper mapper = new CategoryMapper();
            List<CookCategory> categories = DB.CategoryRepository.Get();
            List<CategoryControlModel> models = new List<CategoryControlModel>(categories.Count);
            foreach(var category in categories)
            {
                models.Add(mapper.Map(category));
            }
            CollectionNumerator<CategoryControlModel>.Numerate(models);
            categoryViewModel.AllModels = models;
            categoryViewModel.Categories = new ObservableCollection<CategoryControlModel>(models);

            var mainView = (MainView)viewModel.view;
            mainView.grdMain.Children.Clear();
            mainView.grdMain.Children.Add(categoryControl);
        }
    }
}
