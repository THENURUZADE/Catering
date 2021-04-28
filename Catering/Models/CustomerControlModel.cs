using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Models
{
    public class CustomerControlModel:BaseControlModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
   

        public CustomerControlModel Clone()
        {
            CustomerControlModel model = new CustomerControlModel();
            model.Id = Id;
            model.No = No;
            model.Name = Name;
            model.Phone = Phone;
            model.Email = Email;
            model.Note = Note;
            model.Address = Address;

            return model;
        }
    
    
    
    
    
    
    }
    





}
