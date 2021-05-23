using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Abstracts
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        int Add(Customer customer);
        bool Update(Customer customer);
    }
}
