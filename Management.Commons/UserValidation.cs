using System;
using System.Text.RegularExpressions; //use for Regex
using System.Linq;

namespace Management.Commons
{
    //this class will handle input validations
    public class UserValidation
    {
        //this method will pass in a parameter of name and format the name to the required specifications
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
                var regexItem = new Regex("^[a-zA-Z]*$");
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

        //check for email validity using regex
        public static string ValidateEmail(string email)
        {
            try
            {
                var regexEmail = new Regex(@"^[^@\s\.]+@[^@\s]+\.[^@\s]+$");
                while (!regexEmail.IsMatch(email))
                {
                    Console.WriteLine("Kindly enter a valid email eg user@mail.com");
                    email = Console.ReadLine();
                }
                return email;
            }
            catch (FormatException ex)
            {
                //if an format exception is found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new FormatException(ex.Message);
            }
            catch (Exception e)
            {
                //catches all unpredicted errors and clear console
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(e.Message);
            }
        }

        //check for password
        public static string ValidatePassword(string password)
        {
            try
            {
                //check if string contains special character
                bool containsAtLeastOneSpecialChar = password.Any(ch => ! Char.IsLetterOrDigit(ch));
                //check if string contains alphanumeric
                bool containsAtLeastOneLetter = password.Any(char.IsLetter);	
                
                //check if password is greater than 6 characters
                if (password.Length < 6)
                {
                    System.Console.WriteLine("Kindly include more than 6 characters");
                    password = Console.ReadLine();
                }        
                //check if string contains special character 
                if (containsAtLeastOneSpecialChar == false)
                {
                    System.Console.WriteLine("Kindly include at least one special character eg #");
                    password = Console.ReadLine();
                }    
                //check if string contains alphanumeric
                if(containsAtLeastOneLetter == false)
                {
                    System.Console.WriteLine("Kindly include at least one alphanumeric character eg a");
                    password = Console.ReadLine();
                }   
                return password;
            }
            catch (ArgumentException ex)
            {
                //if a format exception is found
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