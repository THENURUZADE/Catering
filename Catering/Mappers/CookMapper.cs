using Catering.Core.Domain.Entities;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Mappers
{
    public class CookMapper : BaseMapper<CookModel, Cook>
    {
        public override CookModel Map(Cook t)
        {
            CookModel cookModel = new CookModel();
            cookModel.Category = new CategoryControlModel();
            CategoryMapper mapper = new CategoryMapper();

            cookModel.Id = t.Id;
            cookModel.Category = mapper.Map(t.CookCategory);
            cookModel.Name = t.Name;
            cookModel.Note = t.Note;
            cookModel.PortionPrice = t.PortionPrice;
            cookModel.PortionWeight = t.PortionWeight;

            return cookModel;
        }

        public override Cook Map(CookModel t)
        {
            Cook cook = new Cook();
            cook.CookCategory = new CookCategory();
            CategoryMapper mapper = new CategoryMapper();

            cook.Id = t.Id;
            cook.CookCategory = mapper.Map(t.Category);
            cook.Name = t.Name;
            cook.Note = t.Note;
            cook.PortionPrice = t.PortionPrice;
            cook.PortionWeight = t.PortionWeight;

            return cook;
        }
    }
}
