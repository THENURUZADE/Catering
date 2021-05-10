using Catering.Attributes;
using Catering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Models
{
    public class CategoryControlModel:BaseControlModel
    {
        [Export(Name = "Ad")]
        public string Name { get; set; }
        [Export(Name = "Qeyd")]
        public string Note { get; set; }




        public CategoryControlModel Clone()
        {
            CategoryControlModel category = new CategoryControlModel();

            category.Id = Id;
            category.Name = Name;
            category.No = No;
            category.Note = Note;


            return category;

        }


        public bool IsValid()
        {
            if (Name.Length > 30)
            {
                ErrorMetods.InValidLength("Ad", 30);
                return false;
            }
            return true;
        }
    }
}
