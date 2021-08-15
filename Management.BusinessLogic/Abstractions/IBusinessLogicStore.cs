using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Models;

namespace  Management.BusinessLogic
{
    public interface IBusinessLogicStore
    {
        Task<bool> CreateStore(string storeName, string storeNumber, string storeType, int products, int userId);
        
        Task<List<Store>> DisplayStores();

        Task<bool> AddProduct(int products, string storeNumber);
        Task<bool> RemoveProduct(string storeNumber);
    }
}