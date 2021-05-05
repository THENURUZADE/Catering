using Catering.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
