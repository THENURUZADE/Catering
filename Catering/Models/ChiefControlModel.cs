using Catering.Attributes;
using Catering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Models
{
    public class ChiefControlModel : BaseControlModel
    {
        [Export(Name = "Ad")]
        public string Name { get; set; }
        [Export(Name = "Telefon")]
        public string Phone { get; set; }
        [Export(Name = "Email")]
        public string Email { get; set; }
        [Export(Name = "Qeyd")]
        public string Note { get; set; }



        public ChiefControlModel Clone()
        {
            ChiefControlModel chief  = new ChiefControlModel();

            chief.Id = Id;
            chief.Name = Name;
            chief.No = No;
            chief.Phone = Phone;
            chief.Note = Note;
            chief.Email = Email;

            return chief;

        }

        public bool IsValid()
        {
            if (!ErrorMethods.EmailValidationTest(Email))
            {
                return false;
            }
            else if (!ErrorMethods.PhoneValidationTest(Phone))
            {
                return false;
            }
            else if (Name.Length > 30)
            {
                ErrorMethods.InValidLength("Ad", 30);
                return false;
            }
            else if (Email.Length > 30)
            {
                ErrorMethods.InValidLength("Email", 30);
                return false;
            }
            else if (Note?.Length > 250)
            {
                ErrorMethods.InValidLength("Qeyd", 250);
            }
            return true;
        }
    }
}
