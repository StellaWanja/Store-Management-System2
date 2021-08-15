using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.Data
{
    public class UserDataStore : IUserDataStore
    {
        //create connection string
        private const string ConnectionString = @"Data Source= .; Initial Catalog= StoreManagement; Integrated Security= True;";
        //insert into users table using stored procedures
        public async Task<bool> InsertUserUsingStoredProcedures(string firstName, string lastName, string email, string password)
        {
            try
            {
                //create connection instance
                var connection = CreateConnection();
                //open sql file using async
                await connection.OpenAsync();
                //create query - name of stored procedure
                string query = "INSERTINTOUSERSTABLE";
                //create command
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                //add to the table using parameters
                command.Parameters.Add("firstName", SqlDbType.VarChar).Value = firstName;
                command.Parameters.Add("lastName", SqlDbType.VarChar).Value = lastName;
                command.Parameters.Add("email", SqlDbType.VarChar).Value = email;
                command.Parameters.Add("userPassword", SqlDbType.VarChar).Value = password;
                //execute the command
                //ExecuteNonQuery Executes a command that changes the data in the database
                var rows = await command.ExecuteNonQueryAsync();
                //close connection
                await connection.CloseAsync();
                //return rows
                return rows > 0;
            }
            catch (Exception e)
            {             
                throw new Exception(e.Message);
            }       
        }

        //Read users data for login
        public async Task<List<User>> ReadUsersFromDatabase()
        {
            //create conncection
            var connection = CreateConnection();
            //open sql file async
            await connection.OpenAsync();
            //create query to read everything from users table
            string query = "READDATAFROMUSERSTABLE";
            //create command
            SqlCommand command = new SqlCommand(query, connection); 
            //read async
            var reader = await command.ExecuteReaderAsync();
            //create list of users
            List<User> users = new List<User>();
            //read to end/to null
            while(reader.Read())
            {
                //key - name of column in database
                var user = new User
                {
                    Email = reader["Email"].ToString(),
                    Password = reader["UserPassword"].ToString()
                };

                users.Add(user);
            }
            return users;
        }

        //create connection to database
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString);
            return connection;
        }
    }
}