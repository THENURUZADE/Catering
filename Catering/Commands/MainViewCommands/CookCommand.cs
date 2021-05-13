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
    public class CookCommand : BaseCommand
    {
        private MainViewModel mainViewModel;
        public CookCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            CookViewModel cookViewModel = new CookViewModel();
            CooksControl cooksControl = new CooksControl();
            cooksControl.DataContext = cookViewModel;

            List<CookCategory> cookCategories = DB.CategoryRepository.Get();
            List<CategoryControlModel> categories = new List<CategoryControlModel>(cookCategories.Count);
            CategoryMapper categoryMapper = new CategoryMapper();
            foreach (var item in cookCategories)
            {
                categories.Add(categoryMapper.Map(item));
            }
            cookViewModel.Categories = categories;

            List<Cook> cooks = DB.CookRepository.Get();
            CookMapper mapper = new CookMapper();
            List<CookModel> AllCooks = new List<CookModel>(cooks.Count);
            foreach (var item in cooks)
            {
                AllCooks.Add(mapper.Map(item));
            }
            CollectionNumerator<CookModel>.Numerate(AllCooks);
            cookViewModel.AllModels = AllCooks;
            cookViewModel.Cooks = new ObservableCollection<CookModel>(AllCooks);

            MainView mainView = (MainView)mainViewModel.view;
            mainView.grdMain.Children.Clear();
            mainView.grdMain.Children.Add(cooksControl);
        }
    }
}
