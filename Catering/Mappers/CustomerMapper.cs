using Catering.Core.Domain.Entities;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Mappers
{
    public class CustomerMapper : BaseMapper<CustomerControlModel, Customer>
    {
        public override CustomerControlModel Map(Customer t)
        {
            CustomerControlModel customerModel = new CustomerControlModel();
            
            customerModel.Address = t.Address;
            customerModel.Email = t.Email;
            customerModel.Name = t.Name;
            customerModel.Phone = t.Phone;
            customerModel.Id = t.Id;
            customerModel.Note = t.Note;
            
            return customerModel;
        }

        public override Customer Map(CustomerControlModel t)
        {
            Customer customer = new Customer();
            
            customer.Address = t.Address;
            customer.Email = t.Email;
            customer.Name = t.Name;
            customer.Phone = t.Phone;
            customer.Id = t.Id;
            customer.Note = t.Note;

            return customer;
        }
    }
}
