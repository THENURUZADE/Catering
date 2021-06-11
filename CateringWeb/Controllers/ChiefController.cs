using Catering.Web.Helpers;
using Catering.Web.ViewModels;
using Catering.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Web.Mappers;
using Catering.Core;
using Catering.Web.Controllers;
using Microsoft.AspNetCore.Identity;

namespace CateringWeb.Controllers
{
    public class ChiefController : BaseController
    {
        public ChiefController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager)
        {
            
        }
        public IActionResult Index()
        {
            List<Chief> chiefs = DB.ChiefRepository.Get();
            ChiefMapper mapper = new ChiefMapper();
            ChiefViewModel chiefViewModel = new ChiefViewModel();
            chiefViewModel.Chiefs = new List<ChiefModel>();
            foreach (var item in chiefs)
            {
                chiefViewModel.Chiefs.Add(mapper.Map(item));
                chiefViewModel.Chiefs[chiefViewModel.Chiefs.Count - 1].NumberPrefix = "0" + item.Phone.Substring(4, 2);
                chiefViewModel.Chiefs[chiefViewModel.Chiefs.Count - 1].NumberMain = item.Phone.Substring(6);
            }

            EnumarationHelper<ChiefModel>.Numerate(chiefViewModel.Chiefs);

            return View(chiefViewModel);
        }

        [HttpGet]
        public IActionResult SaveChief(int id)
        {
            ChiefModel model = new ChiefModel();

            if (id != 0)
            {
                Chief chief = DB.ChiefRepository.Get(id);

                if (chief == null)
                    return Content("Chief not found");

                ChiefMapper mapper = new ChiefMapper();
                model = mapper.Map(chief);
                model.NumberPrefix = "0" + chief.Phone.Substring(4, 2);
                model.NumberMain = chief.Phone.Substring(6);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveChief(ChiefModel chiefModel)
        {
            chiefModel.Phone = "+994" + chiefModel.Phone;

            ChiefMapper mapper = new ChiefMapper();
            Chief chief = mapper.Map(chiefModel);
            chief.Creator = CurrentUser;

            if (chief.Id == 0)
                DB.ChiefRepository.Add(chief);
            else
                DB.ChiefRepository.Update(chief);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(ChiefViewModel chiefViewModel)
        {
            Chief chief = DB.ChiefRepository.Get(chiefViewModel.DeletedId);

            if (chief == null)
                return Content("Chief not found");

            chief.Creator = CurrentUser;
            chief.LastModifiedDate = DateTime.Now;
            chief.IsDeleted = true;

            DB.ChiefRepository.Update(chief);

            return RedirectToAction("Index");
        }
    }
}
