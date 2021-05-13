using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Abstracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IChiefRepository ChiefRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICookRepository CookRepository { get; }

        bool CheckServer();
    }
}
