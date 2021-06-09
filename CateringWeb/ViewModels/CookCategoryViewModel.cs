using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.ViewModels
{
    public class CookCategoryViewModel
    {
        public List<CookCategoryModel> Categories = new List<CookCategoryModel>();
        public int DeletedId { get; set; }
    }
}
