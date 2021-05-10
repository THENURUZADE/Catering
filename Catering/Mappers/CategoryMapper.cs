using Catering.Core.Domain.Entities;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Mappers
{
    public class CategoryMapper : BaseMapper<CategoryControlModel, CookCategory>
    {
        public override CategoryControlModel Map(CookCategory t)
        {
            CategoryControlModel model = new CategoryControlModel();

            model.Id = t.Id;
            model.Note = t.Note;
            model.Name = t.Name;

            return model;
        }

        public override CookCategory Map(CategoryControlModel t)
        {
            CookCategory category = new CookCategory();

            category.Id = t.Id;
            category.Name = t.Name;
            category.Note = t.Note;

            return category;
        }
    }

}
