using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    //declare methods to use in storedatastore
    public interface IStoreDataStore
    {
        //add stores
        Task<bool> InsertStoreUsingStoredProcedures(string storeName, string storeNumber, string storeType, int products, int userId);
        //read stores
        Task<List<Store>> ReadStoresFromDatabase();
        //update products
        Task<bool> UpdateProducts(int products, string storeNumber);
        //remove products
        Task<bool> DeleteProducts(string storeNumber);
    }
}