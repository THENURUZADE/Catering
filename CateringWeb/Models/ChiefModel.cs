using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Models
{
    public class ChiefModel : BaseModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(13)]
        [MinLength(13, ErrorMessage ="Telefon nomresi '+994551234567' seklinde olmalidir")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(250)]
        public string Note { get; set; }
    }
}
