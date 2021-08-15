using System;
using Management.Commons;

namespace Management.Models
{
    //the user class will hold information about the user such as names and email
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        //use encapsulation to set the details of the user
        private string firstName;
        public string FirstName
        {
            get {return firstName; }
            //set the first name to equal the value of first name that is formatted
            set { firstName = UserValidation.FormatName(value); }
        }

        private string lastName;
        public string LastName
        {
            get {return lastName; }
            set { lastName = UserValidation.FormatName(value); }
        }

        private string email;
        public string Email 
        {
            get{return email;}
            set{email = UserValidation.ValidateEmail(value);}
        }

        private string password;
        public string Password 
        {
            get{return password;}
            set{password = UserValidation.ValidatePassword(value);}
        }
    }
}
