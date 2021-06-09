using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Mappers
{
    public class CookCategoryMapper : BaseMapper<CookCategoryModel, CookCategory>
    {
        public override CookCategoryModel Map(CookCategory entity)
        {
            CookCategoryModel cookCategoryModel = new CookCategoryModel();

            cookCategoryModel.Id = entity.Id;
            cookCategoryModel.Name = entity.Name;
            cookCategoryModel.Note = entity.Note;
            
            return cookCategoryModel;
        }

        public override CookCategory Map(CookCategoryModel model)
        {
            CookCategory cookCategory = new CookCategory();
            cookCategory.Id = model.Id;
            cookCategory.Name = model.Name;
            cookCategory.Note = model.Note;
           
            return cookCategory;
        }
    }
}
