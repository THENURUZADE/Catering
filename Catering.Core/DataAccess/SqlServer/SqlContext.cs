using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    public class SqlContext
    {
        public readonly string connectionString;
        public SqlContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
