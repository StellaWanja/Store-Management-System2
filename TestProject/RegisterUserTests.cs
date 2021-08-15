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
    public class RegisterUserTests
    {
        private IUserDataStore _dataStore;

        private void Setup(bool value = true)
        {
            //create instance of mock test
            var mockIUserDataStore = new Mock<IUserDataStore>();
            //use lambda function
            mockIUserDataStore
                .Setup(data => data.InsertUserUsingStoredProcedures(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            //assign value
            _dataStore = mockIUserDataStore.Object;
        }

        [Test]
        public async Task Register_User_Method_When_Successful()
        {
            //Arrange
            Setup(true);
            UserActions userActions = new UserActions(_dataStore);
            string firstName = "Stella";
            string lastName = "Njoroge";
            string email = "stella@gmail.com";
            string password = "abc#123";

            //Act - user = true since it is bool
            var user = await userActions.RegisterUser(firstName, lastName, email, password);

            //Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(user, true);
        }

        [Test]
        public void Register_User_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            UserActions userActions = new UserActions(_dataStore);
            string firstName = "Stella";
            string lastName = "Njoroge";
            string email = "stella@gmail.com";
            string password = "abc#123";

            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () => await userActions.RegisterUser(firstName, lastName, email, password)
            );

            //Apply a constraint to an actual value, succeeding if the constraint is satisfied and throwing an assertion exception on failure.
            Assert.That(
               async ()=> await userActions.RegisterUser(firstName, lastName, email, password),
               Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}