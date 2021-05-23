using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    class SqlCategoryRepository:BaseRepository,ICategoryRepository
    {
        public SqlCategoryRepository(SqlContext context) : base(context)
        {
        }

        public int Add(CookCategory category)
        {

            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into CookCategories output inserted.Id  
                                  values (@Name,@LastModifiedDate,
                                  @CreatorId,@Note,@IsDeleted)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, category);
                    return (int)cmd.ExecuteScalar();
                }

            }

        }

        private void AddParameters(SqlCommand cmd, CookCategory category)
        {
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@Note", category.Note ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatorId", category.Creator.Id);
            cmd.Parameters.AddWithValue("@IsDeleted", category.IsDeleted);
            cmd.Parameters.AddWithValue("@LastModifiedDate", category.LastModifiedDate);
        }

        public List<CookCategory> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"select * from CookCategories where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<CookCategory> categories = new List<CookCategory>();
                        while (reader.Read())
                        {
                            categories.Add(GetFromReader(reader));
                        }

                        return categories;
                    }
                }
            }
        }

        public bool Update(CookCategory category)                               
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"Update CookCategories Set Name = @Name, LastModifiedDate = @LastModifiedDate,
                                  CreatorId = @CreatorId, 
                                  Note = @Note, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, category);
                    cmd.Parameters.AddWithValue("@Id", category.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private CookCategory GetFromReader(SqlDataReader reader)
        {
            CookCategory category = new CookCategory();
            category.Id = (int)reader["Id"];
            category.Name = (string)reader["Name"];



            category.LastModifiedDate = (DateTime)reader["LastModifiedDate"];
            if (!reader.IsDBNull(reader.GetOrdinal("CreatorId")))
            {
                category.Creator = new User();
                category.Creator.Id = (int)reader["CreatorId"];
            }
            if (reader["Note"] != DBNull.Value)
                category.Note = (string)reader["Note"];

            category.IsDeleted = (bool)reader["IsDeleted"];

            return category;
        }


    }
}
