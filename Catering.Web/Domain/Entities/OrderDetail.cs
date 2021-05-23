using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Entities
{
    public class OrderDetail : BaseEntityWithNote
    {
        public Order Order { get; set; }
        public Cook Cook { get; set; }
        public Chief Chief { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
