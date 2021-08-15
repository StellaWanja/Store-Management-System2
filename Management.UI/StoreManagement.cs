using System;
using System.Threading.Tasks;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class StoreManagement
    {
        private readonly IBusinessLogicStore _actionsStore;

        //use null coalescing operator to return the value of actions operand if not null, else throw exception
        public StoreManagement(IBusinessLogicStore actionsStore)
        {
            _actionsStore = actionsStore ?? throw new ArgumentNullException(nameof(actionsStore));
        }

        private int products;
        private string storeNumber;

        public async Task DisplayOptions()
        {
            Console.WriteLine("Choose one of the options below:");
            Console.WriteLine("1 to Create Store");
            Console.WriteLine("2 to Add products");
            Console.WriteLine("3 to Delete");
            Console.WriteLine("4 to Get the store details and products"); 

            var consoleInput = InputValidation.storeInputValidity(Console.ReadLine());
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
                                StoreRegistration reg = new StoreRegistration(_actionsStore);
                                reg.DisplayStore().Wait();
                            break;
                        case 2:
                            try
                            {
                                System.Console.WriteLine("Enter store number");
                                string storeNumberInput = Console.ReadLine();
                                storeNumber = StoreValidation.FormatStoreNumber(storeNumberInput);
                                
                                System.Console.WriteLine("Enter updated store products");
                                var productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                if(productsInput == -1)
                                {
                                    System.Console.WriteLine("Kindly enter numbers");
                                    productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                }
                                products = StoreValidation.ValidateProducts(productsInput);

                                await _actionsStore.AddProduct(products, storeNumber);
                                Console.WriteLine("Product update successful");
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
                        case 3:
                            try
                            {
                                System.Console.WriteLine("Enter store number");
                                string storeNumberInput = Console.ReadLine();
                                storeNumber = StoreValidation.FormatStoreNumber(storeNumberInput);

                                await _actionsStore.RemoveProduct(storeNumber);
                                Console.WriteLine("Product and store delete successful");
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
                        case 4:
                            try
                            {
                                System.Console.WriteLine("Store Details: ");
                                var stores =  await _actionsStore.DisplayStores();

                                DataDisplayInTable.DisplayDataTable(stores);
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
                        default:
                            break;
                    }
            }
        }        
    }
}