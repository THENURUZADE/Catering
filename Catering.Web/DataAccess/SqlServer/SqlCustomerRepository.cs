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
    public class SqlCustomerRepository : BaseRepository, ICustomerRepository
    {
        public SqlCustomerRepository(SqlContext context) : base(context)
        {
        }
        
        public int Add(Customer customer)
        {
            
            using(SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                
                string cmdText = @"Insert into Customers output inserted.Id  
                                  values (@Name,@Phone, @Email, @Address,
                                  @LastModifiedDate,@CreatorId,@Note,@IsDeleted)";

                using (SqlCommand cmd = new SqlCommand(cmdText,connection))
                {
                    AddParameters(cmd, customer);
                    return (int)cmd.ExecuteScalar();
                }
                
            }
            
        }

        public List<Customer> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Customers where IsDeleted = 0";
                using(SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Customer> customers = new List<Customer>();
                        while (reader.Read())
                        {
                            customers.Add(GetFromReader(reader));
                        }
                        
                        return customers;
                    }
                }
            }

        }

        public bool Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(context.connectionString))
            {
                connection.Open();
                string cmdText = @"Update Customers Set Name = @Name,Phone = @Phone, Address = @Address,
                                  LastModifiedDate = @LastModifiedDate, CreatorId = @CreatorId, 
                                  Note = @Note, IsDeleted = @IsDeleted where Id = @Id" ;
                using (SqlCommand cmd = new SqlCommand(cmdText,connection))
                {
                    AddParameters(cmd, customer);
                    cmd.Parameters.AddWithValue("@Id",customer.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
        private void AddParameters(SqlCommand cmd, Customer customer)
        {
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@LastModifiedDate", customer.LastModifiedDate);
            cmd.Parameters.AddWithValue("@CreatorId", customer.Creator.Id);
            cmd.Parameters.AddWithValue("@Note", customer.Note ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsDeleted", customer.IsDeleted);
        }
    
        private Customer GetFromReader(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.Id = (int)reader["Id"];
            customer.Name = (string)reader["Name"];
            customer.Phone = (string)reader["Phone"];
            if (reader["Email"] != DBNull.Value)
                customer.Email = (string)reader["Email"];

            customer.Address = (string)reader["Address"];
            customer.LastModifiedDate = (DateTime)reader["LastModifiedDate"];
            if (!reader.IsDBNull(reader.GetOrdinal("CreatorId")))
            {
                customer.Creator = new User();
                customer.Creator.Id = (int)reader["CreatorId"];
            }
            if (reader["Note"] != DBNull.Value)
                customer.Note = (string)reader["Note"];

            customer.IsDeleted = (bool)reader["IsDeleted"];
           
            return customer;
        }
    
    
    }
}
