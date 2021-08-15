using System;
using System.Threading.Tasks;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class UserRegistration
    {
        private readonly IBusinessLogicUser _actionsUser;
        private readonly IBusinessLogicStore _actionsStore;

        //use null coalescing operator to return the value of actions operand if not null, else throw exception
        public UserRegistration(IBusinessLogicUser actionsUser, IBusinessLogicStore actionsStore)
        {
            _actionsUser = actionsUser ?? throw new ArgumentNullException(nameof(actionsUser));
            _actionsStore = actionsStore ?? throw new ArgumentNullException(nameof(actionsStore));
        }
        
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string userPassword;

        public async Task DisplayDashboard()
        {
            bool appShouldRun = true;
            while (appShouldRun)
            {
                Console.WriteLine("Welcome to my store management app.");
                Console.WriteLine("Enter: ");
                Console.WriteLine("1 to Register");
                Console.WriteLine("2 to Login");
                Console.WriteLine("0 to exit");

                var consoleInput = InputValidation.accountInputValidity(Console.ReadLine());
                if (consoleInput == -1)
                {
                    Console.WriteLine("Please enter a valid input");
                    Console.Clear();
                }
                else
                {
                    switch (consoleInput)
                    {
                        case 1:
                            try
                            {
                                System.Console.WriteLine("Enter your first name");
                                string firstNameInput = Console.ReadLine();
                                firstName = UserValidation.FormatName(firstNameInput);

                                System.Console.WriteLine("Enter your last name");
                                string lastNameInput = Console.ReadLine();
                                lastName = UserValidation.FormatName(lastNameInput);

                                System.Console.WriteLine("Enter your email");
                                string emailAddressInput = Console.ReadLine();
                                emailAddress = UserValidation.ValidateEmail(emailAddressInput);

                                System.Console.WriteLine("Enter your password");
                                string userPasswordInput = Console.ReadLine();
                                userPassword = UserValidation.ValidatePassword(userPasswordInput);

                                var register = await _actionsUser.RegisterUser(firstName, lastName, emailAddress, userPassword);
                                System.Console.WriteLine($"{firstName} {lastName} has been registered");

                                StoreManagement management = new StoreManagement(_actionsStore);
                                management.DisplayOptions().Wait();
                              
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (FormatException ex) 
                            //Catch all errors relating to argument formats operations
                            {

                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)  
                            //Catch all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            try
                            {
                                System.Console.WriteLine("Enter your email");
                                string emailAddressInput = Console.ReadLine();
                                emailAddress = UserValidation.ValidateEmail(emailAddressInput);

                                System.Console.WriteLine("Enter your password");
                                string userPasswordInput = Console.ReadLine();
                                userPassword = UserValidation.ValidatePassword(userPasswordInput);

                                var login = await _actionsUser.LoginUser(emailAddress, userPassword);

                                if (login == 1)
                                {                                
                                    System.Console.WriteLine($"Login successful");

                                    StoreManagement management = new StoreManagement(_actionsStore);
                                    management.DisplayOptions().Wait();
                               }
                                else
                                {
                                    System.Console.WriteLine("Invalid credentials! Please try again");
                                }
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (FormatException ex) 
                            //Catch all errors relating to argument formats operations
                            {

                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)  
                            //Catch all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 0:
                            try
                            {
                                appShouldRun = false;
                            }
                            catch (Exception e)  //Catches all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}




