using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class SaveCommand : BaseControlCommand<ChiefControlViewModel>
    {
        public SaveCommand(ChiefControlViewModel viewModel):base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Enums.Situation.Normal )
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
                    if (viewModel.Model.IsValid())
                    {
                        var vm = (ChiefControlViewModel)viewModel;
                        Mappers.ChiefMapper mapper = new Mappers.ChiefMapper();
                        Chief chief = mapper.Map(vm.Model);
                        chief.LastModifiedDate = DateTime.Now;
                        chief.Creator = Kernel.CurrentUser;
                        var isupdated = DB.ChiefRepository.Update(chief);
                        if (!isupdated)
                        {
                            MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var ins = vm.Chiefs.IndexOf(vm.SelectedModel);
                        vm.Chiefs[ins] = vm.Model;
                        vm.AllChiefs[ins] = vm.Model;
                        vm.Model = null;
                        vm.SelectedModel = null;
                        viewModel.CurrentSituation = (int)Enums.Situation.Normal;
                    }
                    
                }
                else if (viewModel.CurrentSituation == (int)Enums.Situation.Add)
                {
                    if (viewModel.Model.IsValid())
                    {
                        var vm = (ChiefControlViewModel)viewModel;
                        Mappers.ChiefMapper mapper = new Mappers.ChiefMapper();
                        Chief chief = mapper.Map(vm.Model);
                        chief.Creator = Kernel.CurrentUser;
                        chief.LastModifiedDate = DateTime.Now;
                        var id = DB.ChiefRepository.Add(chief);
                        vm.Model.Id = id;
                        vm.Model.No = vm.AllChiefs.Count + 1;
                        vm.Chiefs.Add(vm.Model);
                        vm.AllChiefs.Add(vm.Model);
                        vm.Model = null;
                        viewModel.CurrentSituation = (int)Enums.Situation.Normal;

                    } 
                }
                


                

            }

            


        }
    }
}
