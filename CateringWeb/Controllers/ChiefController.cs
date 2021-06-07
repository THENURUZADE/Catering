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

namespace CateringWeb.Controllers
{
    public class ChiefController : BaseController
    {
        private readonly IUnitOfWork DB;
        public ChiefController(IUnitOfWork db)
        {
            DB = db;
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
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveChief(ChiefModel chiefModel)
        {
            ChiefMapper mapper = new ChiefMapper();
            Chief chief = mapper.Map(chiefModel);
            chief.Creator = Kernel.CurrentUser;

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

            chief.Creator = Kernel.CurrentUser;
            chief.LastModifiedDate = DateTime.Now;
            chief.IsDeleted = true;

            DB.ChiefRepository.Update(chief);

            return RedirectToAction("Index");
        }
    }
}
