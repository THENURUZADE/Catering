using Catering.Mappers;
using Catering.Models;
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
    public class ChiefCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;
        public ChiefCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {

            var chiefEntityList = DB.ChiefRepository.Get();

            List<ChiefControlModel> chiefModelList = new List<ChiefControlModel>();
            ChiefMapper mapper = new ChiefMapper();
            chiefModelList = chiefEntityList.Select(x => mapper.Map(x)).ToList();

            MainViewNewDesign view = (MainViewNewDesign)viewModel.view;
            view.grdMain.Children.Clear();
            ChiefControlViewModel chiefControlViewModel = new ChiefControlViewModel();

            chiefControlViewModel.AllChiefs = chiefModelList;
            chiefControlViewModel.Chiefs = new System.Collections.ObjectModel.ObservableCollection<ChiefControlModel>(chiefModelList);

            ChiefControl chiefControl = new ChiefControl();
            chiefControl.DataContext = chiefControlViewModel;
            view.grdMain.Children.Add(chiefControl);
        }
    }
}
