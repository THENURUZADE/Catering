using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.ViewModels
{
    public class CookViewModel
    {
        public List<CookModel> Cooks { get; set; } = new List<CookModel>();
        public int DeletedId { get; set; }
    }
}
