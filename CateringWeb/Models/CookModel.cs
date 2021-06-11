using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Models
{
    public class CookModel: BaseModel
    {
        [Required]
        [StringLength(30, ErrorMessage ="Name length must be less 30 characters.")]
        public string Name { get; set; }
        public CookCategoryModel CookCategory { get; set; }

        [Required]
        public decimal PortionWeight { get; set; }

        [Required]
        public decimal PortionPrice { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
