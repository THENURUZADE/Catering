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

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class SaveCommand : BaseControlCommand
    {
        public SaveCommand(ChiefControlViewModel viewModel):base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Enums.CurrentSituation.Normal )
            {
                viewModel.CurrentSituation = (int)Enums.CurrentSituation.Add;
            }
            else if (viewModel.CurrentSituation == (int)Enums.CurrentSituation.Selected)
            {
                viewModel.CurrentSituation = (int)Enums.CurrentSituation.Edit;



                


            }
            else
            {
                if (viewModel.CurrentSituation == (int)Enums.CurrentSituation.Edit)
                {
                    var vm = (ChiefControlViewModel)viewModel;
                    Mappers.ChiefMapper mapper = new Mappers.ChiefMapper();
                    Chief chief = mapper.Map(vm.Model);
                    chief.LastModifiedDate = DateTime.Now;
                    chief.Creator = Kernel.CurrentUser;
                    var isupdated = DB.ChiefRepository.Update(chief);
                    if (!isupdated)
                    {

                    }
                    
                    var ins = vm.Chiefs.IndexOf(vm.SelectedModel);
                    vm.Chiefs[ins] = vm.Model;
                    vm.AllChiefs[ins] = vm.Model;
                    vm.Model = null;
                    viewModel.CurrentSituation = (int)Enums.CurrentSituation.Normal;
                }
                else if (viewModel.CurrentSituation == (int)Enums.CurrentSituation.Add)
                {
                    var vm = (ChiefControlViewModel)viewModel;
                    Mappers.ChiefMapper mapper = new Mappers.ChiefMapper();
                    Chief chief = mapper.Map(vm.Model);
                    chief.Creator = Kernel.CurrentUser;
                    chief.LastModifiedDate = DateTime.Now;
                    var id = DB.ChiefRepository.Add(chief);
                    vm.Model.Id = id;
                    vm.Chiefs.Add(vm.Model);
                    vm.AllChiefs.Add(vm.Model);
                    vm.Model = null;
                    viewModel.CurrentSituation = (int)Enums.CurrentSituation.Normal;
                    CollectionNumerator<ChiefControlModel>.Numerate(vm.Chiefs);
                    CollectionNumerator<ChiefControlModel>.Numerate(vm.AllChiefs);
                }
                


                

            }

            


        }
    }
}
