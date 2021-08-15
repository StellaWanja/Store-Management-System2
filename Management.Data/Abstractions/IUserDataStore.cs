using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    public interface IUserDataStore
    {
        Task<bool> InsertUserUsingStoredProcedures(string firstName, string lastName, string email, string password);

        Task<List<User>> ReadUsersFromDatabase();
    }
}