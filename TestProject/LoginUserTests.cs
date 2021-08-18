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
            //use lambda function
            mockIUserDataStore
                .Setup(data => data.ReadUsersFromDatabase())
                .Returns(Task.FromResult(new List<User>
                { 
                   new User
                   {
                       Email = "stella@gmail.com",
                       Password = "123#abc"
                   }
                }));

            //assign value
           _dataStore = mockIUserDataStore.Object;
        }

        [Test]
        public async Task Login_User_Method_When_Successful()
        {
            //Arrange
            Setup(1);
            UserActions userActions = new UserActions(_dataStore);
            string email = "stella@gmail.com";
            string password = "abc#123";

            //Act - user = true since it is bool
            var user = await userActions.LoginUser(email,password);

            //Assert
            Assert.IsNotNull(user);
            //check if the created instance and the value from the method are equal
            Assert.AreEqual(user, 1);
        }

        //test if fails
        [Test]
        public async Task Login_User_Method_When_Not_Successful()
        {
            //Arrange
            Setup(-1);
            UserActions userActions = new UserActions(_dataStore);
            string email = "stella@gmail.com";
            string password = "abc#123";
            //Act - user = true since it is bool
            var user = await userActions.LoginUser(email,password);

            //Assert
            Assert.AreNotEqual(user, -1);
        }
    }
}