using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static bool IsDbNull(this SqlDataReader reader, string columnname)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnname));
        }
        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
            return (int)reader[columnName];
        }
        public static string GetString(this SqlDataReader reader,string columnname)
        {
            return (string)reader[columnname];
        }
        public static bool GetBool(this SqlDataReader reader, string columnname)
        {
            return (bool)reader[columnname];
        }
        public static DateTime GetDateTime(this SqlDataReader reader, string columnname)
        {
            return (DateTime)reader[columnname];
        }
        public static decimal GetDecimal(this SqlDataReader reader, string columnName)
        {
            return (decimal)reader[columnName];
        }
    }
}
