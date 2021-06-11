using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Models
{
    public class CookModel: BaseModel
    {
        public string Name { get; set; }
        public CookCategoryModel CookCategory { get; set; }
        public decimal PortionWeight { get; set; }
        public decimal PortionPrice { get; set; }
        public string Note { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
