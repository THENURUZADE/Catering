using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Mappers;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.CategoryControlCommands
{
    public class SaveCategoryCommand : BaseControlCommand<CategoryControlViewModel>
    {
        public SaveCategoryCommand(CategoryControlViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Enums.Situation.Normal)
            {
                viewModel.CurrentSituation = (int)Enums.Situation.Add;
            }
            else if (viewModel.CurrentSituation == (int)Enums.Situation.Selected)
            {
                viewModel.CurrentSituation = (int)Enums.Situation.Edit;
            }
            else
            {
                if (viewModel.CurrentSituation == (int)Enums.Situation.Edit)
                {
                    if (viewModel.CurrentModel.IsValid())
                    {
                        var vm = (CategoryControlViewModel)viewModel;
                        Mappers.CategoryMapper mapper = new Mappers.CategoryMapper();
                        CookCategory category = mapper.Map(vm.CurrentModel);
                        category.LastModifiedDate = DateTime.Now;
                        category.Creator = Kernel.CurrentUser;
                        var isupdated = DB.CategoryRepository.Update(category);
                        if (!isupdated)
                        {
                            MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var ins = vm.Categories.IndexOf(vm.SelectedModel);
                        vm.Categories[ins] = vm.CurrentModel;
                        vm.AllModels[ins] = vm.CurrentModel;
                        vm.CurrentModel = null;
                        vm.SelectedModel = null;
                        viewModel.CurrentSituation = (int)Enums.Situation.Normal;
                    }

                }
                else if (viewModel.CurrentSituation == (int)Enums.Situation.Add)
                {
                    if (viewModel.CurrentModel.IsValid())
                    {
                        var vm = viewModel;
                        Mappers.CategoryMapper mapper = new CategoryMapper();
                        CookCategory category = mapper.Map(vm.CurrentModel);
                        category.Creator = Kernel.CurrentUser;
                        category.LastModifiedDate = DateTime.Now;
                        var id = DB.CategoryRepository.Add(category);
                        vm.CurrentModel.Id = id;
                        vm.CurrentModel.No = vm.AllModels.Count + 1;
                        vm.AllModels.Add(vm.CurrentModel);
                        vm.Categories.Add(vm.CurrentModel);
                        vm.CurrentModel = null;
                        viewModel.CurrentSituation = (int)Enums.Situation.Normal;

                    }
                }
            }
        }
    }
}
