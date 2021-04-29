using Catering.Helpers;
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
            ChiefControl chiefControl = new ChiefControl();
            
            ChiefControlViewModel chiefControlViewModel = new ChiefControlViewModel();
            chiefControl.DataContext = chiefControlViewModel;
            chiefControlViewModel.Chiefs = new System.Collections.ObjectModel.ObservableCollection<ChiefControlModel>(chiefModelList);
            chiefControlViewModel.AllChiefs = chiefModelList;
            CollectionNumerator<ChiefControlModel>.Numerate(chiefControlViewModel.Chiefs);
            CollectionNumerator<ChiefControlModel>.Numerate(chiefControlViewModel.AllChiefs);
            

           //  MainView mainWindow = (MainView)viewModel.Window;
            
            view.grdMain.Children.Clear();
            view.grdMain.Children.Add(chiefControl);
        }
    }
}
