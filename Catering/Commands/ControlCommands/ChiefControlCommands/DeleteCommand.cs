using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel.Helper;
using Catering.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class DeleteCommand : BaseControlCommand<ChiefControlViewModel>
    {
        public DeleteCommand(ChiefControlViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            SureDialogBox s = new SureDialogBox();
            SureDialogViewModel svm = new SureDialogViewModel(s);
            s.DataContext = svm;
            s.ShowDialog();
            if (s.DialogResult == true)
            {
                Mappers.ChiefMapper mapper = new Mappers.ChiefMapper();
                Chief chief = mapper.Map(viewModel.Model);
                chief.Creator = Kernel.CurrentUser;
                chief.LastModifiedDate = DateTime.Now;
                chief.IsDeleted = true;
                bool result = DB.ChiefRepository.Update(chief);
                if (!result)
                {
                    MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                int ind = viewModel.Chiefs.IndexOf(viewModel.SelectedModel);
                viewModel.AllChiefs.RemoveAt(ind);
                CollectionNumerator<ChiefControlModel>.Numerate(viewModel.AllChiefs, ind);
                viewModel.Chiefs = new System.Collections.ObjectModel.ObservableCollection<ChiefControlModel>(viewModel.AllChiefs);
                viewModel.Model = null;
                viewModel.CurrentSituation = (int)Enums.Situation.Normal;
                MessageBox.Show(UIMessages.SuccessedMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            
            
        }
    }
}
