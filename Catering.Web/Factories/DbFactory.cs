using Catering.Core.DataAccess.SqlServer;
using Catering.Core.Domain.Abstracts;
using Catering.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Create(ServerType serverType, string connectionString)
        {
            switch (serverType)
            {
                case ServerType.SqlServer:
                    {
                        return new SqlUnitOfWork(connectionString);
                    }
                case ServerType.Oracle:
                    {
                        throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
