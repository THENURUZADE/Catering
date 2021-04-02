using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
    }
}
