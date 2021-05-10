using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel;
using Catering.Views.UserControls;
using Catering.Views.Windows;
using System;
using System.Collections.Generic;
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



            var mainView = (MainView)viewModel.view;
            mainView.grdMain.Children.Clear();
            mainView.grdMain.Children.Add(categoryControl);
        }
    }
}
