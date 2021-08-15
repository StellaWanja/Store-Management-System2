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
    public class AddProductTests
    {
        private IStoreDataStore _dataStore;

        private void Setup(bool value = false)
        {
            //create instance of mock test
            var mockIStoreDataStore = new Mock<IStoreDataStore>();
            //use lambda function
            mockIStoreDataStore
                .Setup(data => data.UpdateProducts(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            //assign value
            _dataStore = mockIStoreDataStore.Object;
        }

        [Test]
        public async Task Add_Product_Method_When_Successful()
        {
            //Arrange
            Setup(true);
            StoreActions storeActions = new StoreActions(_dataStore);
            string storeNumber = "123-abc";
            int products = 150;

            //Act - user = true since it is bool
            var store = await storeActions.AddProduct(products, storeNumber);

            //Assert
            Assert.IsNotNull(store);
            Assert.AreEqual(store, true);
        }

        //test if fails
        [Test]
        public void Add_Product_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            StoreActions storeActions = new StoreActions(_dataStore);
            string storeNumber = "123-abc";
            int products = 150;

            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () => await storeActions.AddProduct(products, storeNumber)
            );

            //Apply a constraint to an actual value, succeeding if the constraint is satisfied and throwing an assertion exception on failure.
            Assert.That(
               async ()=> await storeActions.AddProduct(products, storeNumber),
               Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}