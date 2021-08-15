using System;
using System.Text.RegularExpressions; //use for Regex
using System.Linq;

namespace Management.Commons
{
    public class StoreValidation
    {
        public static string FormatName(string name)
        {
            //use a try\catch to catch any exceptions that may occur
            try
            {
                //if name is empty
                if(name == "")
                {
                    Console.WriteLine("Kindly enter your name");
                    name = Console.ReadLine();
                }

                //use regex to check if name has special characters and re-enter input if it does 
                var regexItem = new Regex("^[a-zA-Z ]*$");
                if(!regexItem.IsMatch(name))
                {
                    Console.WriteLine("Kindly enter your name without using special characters or numbers");
                    name = Console.ReadLine();
                }

                //access the first char of string name
                char firstChar = name[0];
                //if first char is not a number
                if (!char.IsNumber(firstChar))
                {
                    //if the name's first name is capitalized, return name as it is
                    if(firstChar >= 65 && firstChar <= 90)
                    {
                        return name;
                    }
                    //if name's first char is lowercase, convert it to uppercase
                    else if(firstChar >= 97 && firstChar <= 122)
                    {
                        return name.ToUpper()[0] + name.Substring(1);
                    }
                }
                return FormatName(name);
            }
            catch (FormatException ex)
            {
                //if an format exception is found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new FormatException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //if an argument exception is found
                //throw exception message in red that have been written above
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)
            {
                //catches all unpredicted errors and clear console
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(e.Message);
            }
        }

        public static string FormatStoreNumber(string storeNumber)
        {
            try
            {
                var regexStoreNumber = new Regex("^[a-zA-Z0-9-_]*$");
                if(!regexStoreNumber.IsMatch(storeNumber) )
                {
                    Console.WriteLine("Kindly enter your store number without using special characters except hyphen -");
                    storeNumber = Console.ReadLine();
                }
                return storeNumber;
            }
            catch (FormatException ex)
            {
                //if an format exception is found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new FormatException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //if an argument exception is found
                //throw exception message in red that have been written above
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)
            {
                //catches all unpredicted errors and clear console
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(e.Message);
            }
        }

        public static int IsValidInput(string data)
        {
            bool isValid = Int32.TryParse(data, out int value);
            if (!isValid)
            {
                return -1;
            }
            return value;
        }


        public static int ValidateProducts(int products)
        {
            try
            {
                if(products < 100)
                {
                    Console.WriteLine("Kindly input at least 100 products");
                    products = IsValidInput(Console.ReadLine());
                }
                return products;
            }
            catch (ArgumentException ex)
            {
                //if an argument exception is found
                //throw exception message in red that have been written above
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)
            {
                //catches all unpredicted errors and clear console
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(e.Message);
            }
        }
    }
}