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
    public class LoginUserTests
    {
        private IUserDataStore _dataStore;

        //used without parameters
        // [SetUp]
        private void Setup(int value = -1)
        {
            //create instance of mock test
            var mockIUserDataStore = new Mock<IUserDataStore>();
            //create an instance that holds the result of List<User>
            var userProperties = _dataStore.ReadUsersFromDatabase().Result;
            //use lambda function
            mockIUserDataStore
                .Setup(data => data.ReadUsersFromDatabase())
                .Returns(Task.FromResult(userProperties));

            //assign value
           _dataStore = mockIUserDataStore.Object;
        }

        [Test]
        public async Task Login_User_Method_When_Successful()
        {
            //Arrange
            Setup(1);
            UserActions userActions = new UserActions(_dataStore);
            var userProperties = _dataStore.ReadUsersFromDatabase().Result;
            string email = "stella@gmail.com";
            string password = "abc#123";

            //Act - user = true since it is bool
            var user = await userActions.LoginUser(email,password);

            //Assert
            Assert.IsNotNull(user);
            //check if the created instance and the value from the method are equal
            Assert.AreEqual(user, userProperties);
        }

        //test if fails
        [Test]
        public async Task Login_User_Method_When_Not_Successful()
        {
            //Arrange
            Setup(-1);
            UserActions userActions = new UserActions(_dataStore);
            var userProperties = _dataStore.ReadUsersFromDatabase().Result;
            string email = "stella@gmail.com";
            string password = "abc#123";
            //Act - user = true since it is bool
            var user = await userActions.LoginUser(email,password);

            //Assert
            Assert.AreNotEqual(user, userProperties);

            //Apply a constraint to an actual value, succeeding if the constraint is satisfied and throwing an assertion exception on failure.
            // Assert.That(
            //    async ()=> await userActions.LoginUser(),
            //    Throws.InstanceOf(typeof(TimeoutException))
            // );
        }
    }
}