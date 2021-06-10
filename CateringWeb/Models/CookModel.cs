using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Models
{
    public class CookModel: BaseModel
    {
        public string Name { get; set; }
        public CookCategory CookCategory { get; set; }
        public decimal PortionWeight { get; set; }
        public decimal PortionPrice { get; set; }
        public string Note { get; set; }
    }
}
