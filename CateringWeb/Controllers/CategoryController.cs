using Catering.Core;
using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Web.Helpers;
using Catering.Web.Mappers;
using Catering.Web.Models;
using Catering.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork db, UserManager<User> userManager):base(db, userManager)
        {

        }
        public IActionResult Index()
        {
            CookCategoryViewModel categoryViewModel = new CookCategoryViewModel();
            CookCategoryMapper mapper = new CookCategoryMapper();
            List<CookCategoryModel> cookCategoryModels = new List<CookCategoryModel>();
            List<CookCategory> cookCategories = DB.CategoryRepository.Get();

            foreach (var item in cookCategories)
            {
                CookCategoryModel cookCategoryModel = mapper.Map(item);
                cookCategoryModels.Add(cookCategoryModel);
            }
            EnumarationHelper<CookCategoryModel>.Numerate(cookCategoryModels);
            categoryViewModel.Categories = cookCategoryModels;
            return View(categoryViewModel);
        }
        public IActionResult SaveCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(CookCategoryViewModel cookCategoryViewModel)
        {
            CookCategory category = DB.CategoryRepository.Get(cookCategoryViewModel.DeletedId);
            category.IsDeleted = true;
            DB.CategoryRepository.Update(category);
            category.Creator = CurrentUser;
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult SaveCategory (int id)
        {

            CookCategoryModel model = new CookCategoryModel();
            if (id==0)
            {
                
            }
            else
            {
                CookCategoryMapper mapper = new CookCategoryMapper();
                CookCategory category = DB.CategoryRepository.Get(id);
                model = mapper.Map(category);
            }
            return View(model);
        }

        
        [HttpPost]
        public IActionResult SaveCategory(CookCategoryModel model)
        {
            
            if (ModelState.IsValid==true)
            {
                CookCategoryMapper mapper = new CookCategoryMapper();
                CookCategory cookCategory = mapper.Map(model);
                cookCategory.Creator = CurrentUser;
                if (model.Id==0)
                {
                    DB.CategoryRepository.Add(cookCategory);
                }
                else
                {
                    DB.CategoryRepository.Update(cookCategory);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return Content("Məlumat düzgün daxil edilməyib. Yenidən cəhd edin !! ");
            }
        }

    }
}
