using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace Catering.Core.DataAccess.SqlServer
{
    class SqlChiefRepository : BaseRepository, IChiefRepository
    {
        public SqlChiefRepository(SqlContext context):base(context)
        {

        }

        public int Add(Chief chief)
        {
            using (SqlConnection con = new SqlConnection(context.connectionString))
            {
                con.Open();
                string command = @"insert into Chiefs output inserted.id Values(@name,@phone,@email,@lastmodifieddate,
                                                                                @creatorid,@note,@isdeleted)";
                using (SqlCommand com = new SqlCommand(command))
                {
                    AddParameters(com, chief);

                    return (int)com.ExecuteScalar();
                }
            }
        }

        public List<Chief> Get()
        {
            using (SqlConnection con = new SqlConnection(context.connectionString))
            {
                con.Open();
                string command = "select * from Chiefs where  isdeleted = 0";
                using (SqlCommand com = new SqlCommand(command))
                {

                    List<Chief> chiefs = new List<Chief>();

                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        var Creator = new User()
                        {
                            Id = reader.GetInt32("creatorid")
                        };
                        Chief chief = new Chief()
                        {
                            Id = reader.GetInt32("id"),
                            IsDeleted = false,
                            LastModifiedDate = reader.GetDateTime("lastmodifieddate"),
                            Name = reader.GetString("name"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                            Creator = Creator
                         };
                        chiefs.Add(chief);
                    }
                    return chiefs;
                }
            }
        }

        public bool Update(Chief chief)
        {
            using (SqlConnection con = new SqlConnection(context.connectionString))
            {
                con.Open();
                string command = @"Update Chiefs set name = @name, phone = @phone, email = @email, lastmodifieddate = @lastmodifieddate
                                                        creatorid = @creatorid, note = @note, isdeleted = @isdeleted where id = @id";
                using (SqlCommand com = new SqlCommand(command))
                {
                    AddParameters(com, chief);
                    com.Parameters.AddWithValue("@id", chief.Id);

                    return com.ExecuteNonQuery() == 1;
                }
            }
        }

        private void AddParameters(SqlCommand com,Chief chief)
        {
            com.Parameters.AddWithValue("@name", chief.Name);
            com.Parameters.AddWithValue("@phone", chief.Phone);
            com.Parameters.AddWithValue("@email", chief.Email);
            com.Parameters.AddWithValue("@note", chief.Note ?? (object)DBNull.Value);
            com.Parameters.AddWithValue("@creatorid", chief.Creator.Id);
            com.Parameters.AddWithValue("@isdeleted", chief.IsDeleted);
            com.Parameters.AddWithValue("@lastmodifieddate", chief.LastModifiedDate);

        }
    }
}
