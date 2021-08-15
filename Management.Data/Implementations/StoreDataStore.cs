using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.Data
{
    public class StoreDataStore : IStoreDataStore
    {
        //create connection string
        private const string ConnectionString = @"Data Source= .; Initial Catalog= StoreManagement; Integrated Security= True;";
        //insert into stores table using stored procedures
        public async Task<bool> InsertStoreUsingStoredProcedures(string storeName, string storeNumber, string storeType, int products, int userId)
        {
            try
            {
                //create connection instance
                var connection = CreateConnection();
                //open sql file using async
                await connection.OpenAsync();
                //create query - name of stored procedure
                string query = "INSERTINTOSTORESTABLE";
                //create command
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                //add to the table using parameters
                command.Parameters.Add("storeName", SqlDbType.VarChar).Value = storeName;
                command.Parameters.Add("storeNumber", SqlDbType.VarChar).Value = storeNumber;
                command.Parameters.Add("storeType", SqlDbType.VarChar).Value = storeType;
                command.Parameters.Add("products", SqlDbType.Int).Value = products;
                command.Parameters.Add("userId", SqlDbType.Int).Value = userId;
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
        public async Task<List<Store>> ReadStoresFromDatabase()
        {
            try
            {
                //create conncection
                var connection = CreateConnection();
                //open sql file async
                await connection.OpenAsync();
                //create query to read everything from users table
                string query = "READDATAFROMSTORESTABLE";
                //create command
                SqlCommand command = new SqlCommand(query, connection); 
                //read async
                var reader = await command.ExecuteReaderAsync();
                //create list of users
                List<Store> stores = new List<Store>();
                //read to end/to null
                while(reader.Read())
                {
                    //key - name of column in database
                    var store = new Store
                    {
                        StoreName = reader["StoreName"].ToString(),
                        StoreNumber = reader["StoreNumber"].ToString(),
                        StoreType = reader["StoreType"].ToString(),
                        Products = (int)reader["Products"],
                        UserId = reader["UserId"].ToString()
                    };

                    stores.Add(store);
                }
                return stores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //update products
        public async Task<bool> UpdateProducts(int products, string storeNumber)
        {
            try
            {
                //create connection
                var connection = CreateConnection();
                //open
                await connection.OpenAsync();
                //query for updating
                string query = "UPDATE Stores SET Products = @Products WHERE StoreNumber = @StoreNumber";
                //create command
                SqlCommand command = new SqlCommand(query, connection);
                //add using parameters
                command.Parameters.Add("Products", SqlDbType.Int).Value = products;
                command.Parameters.Add("StoreNumber", SqlDbType.VarChar).Value = storeNumber;
                //execute async
                var rows = await command.ExecuteNonQueryAsync();

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //delete products
        public async Task<bool> DeleteProducts(string storeNumber)
        {
            try
            {
                var connection = CreateConnection();
                await connection.OpenAsync();

                string query = "DELETE FROM Stores WHERE StoreNumber = @StoreNumber";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("StoreNumber", SqlDbType.Int).Value = storeNumber;

                var rows = await command.ExecuteNonQueryAsync();

                return rows > 0;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        
        //create connection to database
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString);
            return connection;
        }
    }
}