using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Core.Domain.Enums;
using Extensions;
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
                return null;

            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();

                string cmdText = @"select U.*,R.ID as RoleId, R.Name as RoleName from Users as U 
                                   inner join UserRoles as UR on ur.userid = u.id
                                   inner join Roles as R on UR.roleid = r.id 
                                   where U.username = @username and U.isDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    var reader = cmd.ExecuteReader();

                    User user = null;

                    while (reader.Read())
                    {
                        GetFromReader(reader, ref user);
                    }
                    return user;
                }
            }
        }

        public User Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();

                string cmdText = @"select U.*,R.ID as RoleId, R.Name as RoleName from Users as U 
                                   inner join UserRoles as UR on ur.userid = u.id
                                   inner join Roles as R on UR.roleid = r.id 
                                   where U.id = @id and U.isDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    var reader = cmd.ExecuteReader();

                    User user = null;

                    while (reader.Read())
                    {
                        GetFromReader(reader, ref user);
                    }

                    return user;
                }
            }
        }

        private void GetFromReader(SqlDataReader reader, ref User user)
        {

            if (user == null)
            {
                user = new User();

                user.Id = (int)reader["Id"];
                user.Name = (string)reader["Username"];
                user.Password = (string)reader["Password"];
                user.Note = (string)reader["Note"];
                user.LastModifiedDate = (DateTime)reader["LastModifiedDate"];
                user.IsDeleted = false;
                user.Phone = (string)reader["Phone"];
                user.Email = (string)reader["Email"];
                if (!reader.IsDBNull(reader.GetOrdinal("CreatorId")))
                    user.Creator = new User() { Id = (int)reader["CreatorId"] };
                user.Salary = (decimal)reader["Salary"];
            }

            Role role = new Role();
            role.ID = reader.GetInt32("RoleId");
            role.Name = reader.GetString("RoleName");

            user.UserRoles.Add(role);
        }
    }
}
