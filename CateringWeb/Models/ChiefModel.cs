using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CateringWeb.Models
{
    public class ChiefModel : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
