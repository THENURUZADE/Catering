using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    public class SqlCookRepository : BaseRepository, ICookRepository
    {
        public SqlCookRepository(SqlContext context) : base(context) { }

        public int Add(Cook cook)
        {
            using(SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"insert into Cooks output inserted.Id values(@Name,
                                   @CookCategoryId, @PortionWeight,
                                   @PortionPrice, @LastModifiedDate,
                                   @CreatorId, @Note, @IsDeleted)";
                
                using(SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, cook);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public List<Cook> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"select c.*, cg.Name as CategoryName from cooks as c 
                                   join CookCategories as cg On cg.id = c.CookCategoryId where c.IsDeleted = 0";

                using(SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    List<Cook> Cooks = new List<Cook>(); 
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cook cook;
                            cook = GetFromReader(reader);

                            Cooks.Add(cook);
                        }

                        return Cooks;
                    }
                }
            }
        }

        public bool Update(Cook cook)
        {
            using(SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"update Cooks set Name = @Name, CookCategoryId = @CookCategoryId, 
                                   PortionWeight = @PortionWeight, PortionPrice = @PortionPrice, 
                                   LastModifiedDate = @LastModifiedDate, CreatorId = @CreatorId,
                                   Note = @Note, IsDeleted = @IsDeleted where Id = @Id";

                using(SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, cook);
                    cmd.Parameters.AddWithValue("@Id", cook.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private void AddParameters(SqlCommand cmd, Cook cook)
        {
            cmd.Parameters.AddWithValue("@Name", cook.Name);
            cmd.Parameters.AddWithValue("@CookCategoryId", cook.CookCategory.Id);
            cmd.Parameters.AddWithValue("@PortionWeight", cook.PortionWeight);
            cmd.Parameters.AddWithValue("@PortionPrice", cook.PortionPrice);
            cmd.Parameters.AddWithValue("@LastModifiedDate", cook.LastModifiedDate);
            cmd.Parameters.AddWithValue("@CreatorId", cook.Creator.Id);
            cmd.Parameters.AddWithValue("@Note", cook.Note ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsDeleted", cook.IsDeleted);
        }

        private Cook GetFromReader(SqlDataReader reader)
        {
            Cook cook = new Cook();
            cook.Creator = new User();
            cook.CookCategory = new CookCategory();

            cook.Id = reader.GetInt32("Id");
            cook.Name = reader.GetString("Name");
            cook.Creator.Id = reader.GetInt32("CreatorId");
            cook.IsDeleted = reader.GetBool("IsDeleted");
            cook.LastModifiedDate = reader.GetDateTime("LastModifiedDate");
            if (!reader.IsDbNull("Note"))
                cook.Note = reader.GetString("Note");
            cook.PortionPrice = reader.GetDecimal("PortionPrice");
            cook.PortionWeight = reader.GetDecimal("PortionPrice");
            cook.CookCategory.Id = reader.GetInt32("CookCategoryId");
            cook.CookCategory.Name = reader.GetString("CategoryName");

            return cook;
        }
    }
}
