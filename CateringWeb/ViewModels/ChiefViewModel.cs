using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.ViewModels
{
    public class ChiefViewModel
    {
        public List<ChiefModel> Chiefs = new List<ChiefModel>();
        public int DeletedId { get; set; }
    }
}
