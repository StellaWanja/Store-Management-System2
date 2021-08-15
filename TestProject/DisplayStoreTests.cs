using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using Management.BusinessLogic;
using Management.Models;
using Management.Data;

namespace TestProject
{
    //handle mock tests on BusinessLogic operations
    public class DisplayStoreTests
    {
        private IStoreDataStore _dataStore;

        //used without parameters
        [SetUp]
        private void Setup()
        {
            //create instance of mock test
            var mockIStoreDataStore = new Mock<IStoreDataStore>();
            //create an instance that holds the result of List<Store>
            var storeProperties = _dataStore.ReadStoresFromDatabase().Result;
            //use lambda function
            mockIStoreDataStore
                .Setup(data => data.ReadStoresFromDatabase())
                .Returns(Task.FromResult(storeProperties));

            //assign value
           _dataStore = mockIStoreDataStore.Object;
        }

        [Test]
        public async Task Display_Product_Method_When_Successful()
        {
            //Arrange
            StoreActions storeActions = new StoreActions(_dataStore);
            var storeProperties = _dataStore.ReadStoresFromDatabase().Result;
            //Act - user = true since it is bool
            var store = await storeActions.DisplayStores();

            //Assert
            Assert.IsNotNull(store);
            //check if the created instance and the value from the method are equal
            Assert.AreEqual(store, storeProperties);
        }

        //test if fails
        [Test]
        public void Display_Product_Method_When_Not_Successful()
        {
            //Arrange
            StoreActions storeActions = new StoreActions(_dataStore);
            var storeProperties = _dataStore.ReadStoresFromDatabase().Result;
            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () => await storeActions.DisplayStores()
            );

            //Apply a constraint to an actual value, succeeding if the constraint is satisfied and throwing an assertion exception on failure.
            Assert.That(
               async ()=> await storeActions.DisplayStores(),
               Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}