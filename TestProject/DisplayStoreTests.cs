using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        private void Setup(bool value = false)
        {
            //create instance of mock test
            var mockIStoreDataStore = new Mock<IStoreDataStore>();
            //create an instance that holds the result of List<Store>
            //use lambda function
            mockIStoreDataStore
                .Setup(data => data.ReadStoresFromDatabase())
                .Returns(Task.FromResult(new List<Store>
                { 
                    new Store 
                    {
                        StoreName = "Kiosk One",
                        StoreNumber = "123-abc",
                        StoreType = "Kiosk",
                        Products = 100,
                        UserId = "200"
                    }
                }));

            //assign value
           _dataStore = mockIStoreDataStore.Object;
        }

        [Test]
        public async Task Display_Product_Method_When_Successful()
        {
            //Arrange
            Setup(true);
            StoreActions storeActions = new StoreActions(_dataStore);
            //Act - user = true since it is bool
            var store = await storeActions.DisplayStores();

            //Assert
            Assert.IsNotNull(store);
            //check if the created instance and the value from the method are equal
            Assert.AreEqual(store, true);
        }

        //test if fails
        [Test]
        public void Display_Product_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            StoreActions storeActions = new StoreActions(_dataStore);
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