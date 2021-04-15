using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    public class SqlUserRepository : BaseRepository, IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context)
        {

        }

        public User Get(string username)
        {
            if (username == null)
                throw new ArgumentException("Username can not be null");

            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();

                string cmdText = "select * from users where username = @username and isDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        User user = new User();
                        user.Id = (int)reader["Id"];
                        user.Username = (string)reader["Username"];
                        user.Password = (string)reader["Password"];
                        user.Note = (string)reader["Note"];
                        user.LastModifiedDate = (DateTime)reader["LastModifiedDate"];
                        user.IsDeleted = false;
                        user.Role = (UserRole)reader["Role"];
                        user.Phone = (string)reader["Phone"];
                        user.Email = (string)reader["Email"];
                        if (!reader.IsDBNull(reader.GetOrdinal("CreatorId")))
                            user.Creator = new User() { Id = (int)reader["CreatorId"] };
                        user.Salary = (decimal)reader["Salary"];
                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
