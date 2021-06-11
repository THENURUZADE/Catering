using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Web.Helpers;
using Catering.Web.Mappers;
using Catering.Web.Models;
using Catering.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Controllers
{
    public class CookController : BaseController
    {
        public CookController(IUnitOfWork Db,UserManager<User> userManager) : base(Db,userManager)
        {
        }
        
        
        
        
        [HttpGet]
        public IActionResult Index()
        {
            CookViewModel viewModel = new CookViewModel();
            List<Cook> cooks = DB.CookRepository.Get();
            CookMapper mapper = new CookMapper();

            foreach (var item in cooks)
            {
                viewModel.Cooks.Add(mapper.Map(item));
            }

            EnumarationHelper<CookModel>.Numerate(viewModel.Cooks);

            return View(viewModel);
        }
        
       [HttpPost]
        public IActionResult Delete(CookViewModel viewModel)
        {
            Cook cook = DB.CookRepository.Get(viewModel.DeletedId);

            if (cook == null)
                return Content("Cook not found");

            cook.IsDeleted = true;
            cook.Creator = CurrentUser;

            DB.CookRepository.Update(cook);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SaveCook(int id)
        {
            CookMapper mapper = new CookMapper();
            CookCategoryMapper categoryMapper = new CookCategoryMapper();

            CookModel model = mapper.Map(DB.CookRepository.Get(id)) ?? new CookModel();

            List<CookCategory> categories = DB.CategoryRepository.Get();
            List<CookCategoryModel> categoryModels = new List<CookCategoryModel>();

            foreach (var item in categories)
            {
                categoryModels.Add(categoryMapper.Map(item));
            }

            model.Categories = new List<SelectListItem>(categoryModels.Count);

            foreach (var item in categoryModels)
            {
                model.Categories.Add(new SelectListItem(item.Name, item.Id.ToString()));
            }

            if (model.CookCategory == null)
                model.CookCategory = new CookCategoryModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveCook(CookModel model)
        {
            if (model == null)
                return Content("Try again");

            CookMapper mapper = new CookMapper();
            Cook cook = mapper.Map(model);
            cook.Creator = CurrentUser;

            if (model.Id != 0)
                DB.CookRepository.Update(cook);
            else
                DB.CookRepository.Add(cook);

            return RedirectToAction("Index");
        }
    
    }
}
