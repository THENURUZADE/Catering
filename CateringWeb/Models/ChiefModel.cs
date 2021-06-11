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

        private string phone;

        public string Phone
        {
            get => RegionPrefix + NumberPrefix.Remove(0, 1) + NumberMain;
            set
            {
                phone = value;
            }
        }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public string RegionPrefix => "+994";
        public string NumberPrefix { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{7}", ErrorMessage = "Example pattern of phone: 1234567")]
        public string NumberMain { get; set; }
    }
}
