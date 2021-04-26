using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extesions
{
    public static class SqlDataReaderExtensions
    {
        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
            return (int)reader[columnName];
        }
    }
}
