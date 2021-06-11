using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
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
            return View(viewModel);
        }
        
       [HttpPost]
        public IActionResult Delete(CookViewModel viewModel)
        {
            return RedirectToAction();
        }
        [HttpGet]
        public IActionResult SaveCook(int id)
        {
            CookMapper mapper = new CookMapper();
            CookModel model = mapper.Map(DB.CookRepository.Get(id));
            CookCategoryMapper categoryMapper = new CookCategoryMapper();
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

            return View(model);
        }
       [HttpPost]
        public IActionResult SaveCook(CookModel model)
        {
            return View();
        }
    
    }
}
