using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Enums;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel.Helper;
using Catering.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.CookControlCommands
{
    public class DeleteCookCommand : BaseCookCommand
    {
        public DeleteCookCommand(CookViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            SureDialogBox sureDialog = new SureDialogBox();
            SureDialogViewModel sureViewModel = new SureDialogViewModel(sureDialog);
            sureDialog.DataContext = sureViewModel;
            sureDialog.ShowDialog();

            if (sureDialog.DialogResult == true)
            {
                CookMapper mapper = new CookMapper();
                Cook cook = mapper.Map(viewModel.SelectedModel);
                cook.Creator = Kernel.CurrentUser;
                cook.LastModifiedDate = DateTime.Now;
                cook.IsDeleted = true;

                DB.CookRepository.Update(cook);
                CookModel model = viewModel.AllModels.FirstOrDefault(x => x.Id == viewModel.SelectedModel.Id);
                int index = viewModel.AllModels.IndexOf(model);
                viewModel.AllModels.Remove(model);
                viewModel.Cooks.Remove(viewModel.SelectedModel);
                CollectionNumerator<CookModel>.Numerate(viewModel.AllModels, index);
                viewModel.Cooks = new ObservableCollection<CookModel>(viewModel.AllModels);

                viewModel.CurrentSituation = (int)Situation.Normal;
                viewModel.SelectedModel = null;
                viewModel.CurrentModel = new CookModel();

                MessageBox.Show(UIMessages.SuccessedMessage);
            }
        }
    }
}
