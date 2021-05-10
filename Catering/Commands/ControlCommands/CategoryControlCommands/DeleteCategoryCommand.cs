using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Mappers;
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

namespace Catering.Commands.ControlCommands.CategoryControlCommands
{
    public class DeleteCategoryCommand : BaseControlCommand<CategoryControlViewModel>
    {
        public DeleteCategoryCommand(CategoryControlViewModel viewModel) : base(viewModel)
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
                CategoryMapper mapper = new CategoryMapper();
                CookCategory category = mapper.Map(viewModel.CurrentModel);
                category.Creator = Kernel.CurrentUser;
                category.LastModifiedDate = DateTime.Now;
                category.IsDeleted = true;
                bool result = DB.CategoryRepository.Update(category);
                if (!result)
                {
                    MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                int ind = viewModel.Categories.IndexOf(viewModel.SelectedModel);
                viewModel.AllModels.RemoveAt(ind);
                CollectionNumerator<CategoryControlViewModel>.Numerate(viewModel.AllModels, ind);
                viewModel.Categories = new System.Collections.ObjectModel.ObservableCollection<CategoryControlModel>(viewModel.AllModels);
                viewModel.CurrentModel = null;
                viewModel.CurrentSituation = (int)Enums.Situation.Normal;
                MessageBox.Show(UIMessages.SuccessedMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);

            }


        }
    }
}
