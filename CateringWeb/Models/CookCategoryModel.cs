using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Models
{
    public class CookCategoryModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Note { get; set; }
    }
}
