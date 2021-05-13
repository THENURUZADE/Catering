using Catering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Models
{
    public class CookModel : BaseControlModel
    {
        public string Name { get; set; }
        public CategoryControlModel Category { get; set; }
        public decimal PortionWeight { get; set; }
        public decimal PortionPrice { get; set; }
        public string Note { get; set; }

        public CookModel Clone()
        {
            CookModel newModel = new CookModel();

            newModel.Id = Id;
            newModel.No = No;
            newModel.Name = Name;
            newModel.Note = Note;
            newModel.PortionPrice = PortionPrice;
            newModel.PortionWeight = PortionWeight;
            newModel.Category = Category.Clone();

            return newModel;
        }
        
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMethods.InValidSpace("Yemək adı");
                return false;
            }
            if(Name.Length >= 25)
            {
                ErrorMethods.InValidLength("Yemək adı", 25);
                return false;
            }
            if(Category == null)
            {
                ErrorMethods.InValidSpace("Kateqoriya");
                return false;
            }

            return true;
        }
    }
}
