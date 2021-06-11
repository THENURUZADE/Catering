using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Mappers
{
    public class CookMapper : BaseMapper<CookModel, Cook>
    {
        public override CookModel Map(Cook entity)
        {
            CookModel model = new CookModel();
           
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Note = entity.Note;
            model.PortionPrice = entity.PortionPrice;
            model.PortionWeight = entity.PortionWeight;

            if(entity.CookCategory != null)
            {
                CookCategoryMapper mapper = new CookCategoryMapper();
                CookCategoryModel categoryModel = mapper.Map(entity.CookCategory);
                model.CookCategory = categoryModel;
            }
          
            return model;
        }

        public override Cook Map(CookModel model)
        {
            Cook cook = new Cook();
            cook.Id = model.Id;
            cook.Name = model.Name;
            cook.Note = model.Note;
            cook.PortionPrice = model.PortionPrice;
            cook.PortionWeight = model.PortionWeight;
            if (model.CookCategory != null)
            {
                CookCategoryMapper mapper = new CookCategoryMapper();
                CookCategory category = mapper.Map(model.CookCategory);
                cook.CookCategory = category;
            }

            return cook;

        }
    }
}
