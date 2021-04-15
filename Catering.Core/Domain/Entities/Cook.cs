using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Entities
{
    public class Cook : BaseEntityWithNote
    {
        public string Name { get; set; }
        public CookCategory CookCategory { get; set; }
        public decimal PortionWeight { get; set; }
        public decimal PortionPrice { get; set; }
    }
}
