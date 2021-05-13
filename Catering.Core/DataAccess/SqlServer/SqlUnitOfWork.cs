using Catering.Core.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;
        public SqlUnitOfWork(string connectionString)
        {
            context = new SqlContext(connectionString);
        }
        public IUserRepository UserRepository => new SqlUserRepository(context);
        public IChiefRepository ChiefRepository => new SqlChiefRepository(context);
        public ICustomerRepository CustomerRepository => new SqlCustomerRepository(context);
        public ICategoryRepository CategoryRepository => new SqlCategoryRepository(context);
        public ICookRepository CookRepository => new SqlCookRepository(context);

        public bool CheckServer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(context.connectionString))
                {
                    connection.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
