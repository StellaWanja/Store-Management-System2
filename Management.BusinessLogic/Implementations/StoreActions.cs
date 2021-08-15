using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class StoreActions: IBusinessLogicStore
    {
        //actions to collect data from store
        private readonly IStoreDataStore _dataStore;
        public StoreActions(IStoreDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        //create store method
        public async Task<bool> CreateStore(string storeName, string storeNumber, string storeType, int products, int userId)
        {
            StoreDataStore dataConnection = new StoreDataStore();
            //Wait - use for async await - return void
            //.Result - used if method returns value
            var result = await dataConnection.InsertStoreUsingStoredProcedures(storeName, storeNumber, storeType, products, userId);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create user instance at this time"); 
        }

        //save changes to store
        // public async Task SaveStoreChanges()
        // {
        //     await _dataStore.WriteStoreDataToFile();
        // }

        //add product method
        public async Task<bool> AddProduct(int products, string storeNumber)
        {
            StoreDataStore dataConnection = new StoreDataStore();
            var result = await dataConnection.UpdateProducts(products, storeNumber);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create user instance at this time"); 
        }

        //remove product method
        public async Task<bool> RemoveProduct(string storeNumber)
        {
            StoreDataStore dataConnection = new StoreDataStore();
            var result = await dataConnection.DeleteProducts(storeNumber);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create user instance at this time"); 
        }

        //display stores
        public async Task<List<Store>> DisplayStores()
        {
            StoreDataStore dataConnection = new StoreDataStore();
            var dataList = await dataConnection.ReadStoresFromDatabase();
            return dataList;
        }
    }
}
