using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
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
            return View();
        }
        
       [HttpPost]
        public IActionResult Delete(CookViewModel viewModel)
        {
            return RedirectToAction();
        }
        [HttpGet]
        public IActionResult SaveCook(int id)
        {
            return View();
        }
       [HttpPost]
        public IActionResult SaveCook(CookModel model)
        {
            return View();
        }
    
    }
}
