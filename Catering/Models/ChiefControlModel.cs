using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Models
{
    public class ChiefControlModel: BaseControlModel
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

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
