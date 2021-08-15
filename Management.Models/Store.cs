using System;
using Management.Commons;

namespace Management.Models
{
    //the store class will hold information about the store such as names and products
    public class Store
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }

        //use encapsulation to set the details of the store
        private string storeName;
        public string StoreName
        {
            get {return storeName; }
            //set the first name to equal the value of first name that is formatted
            set { storeName = StoreValidation.FormatName(value); }
        }

        private string storeNumber;
        public string StoreNumber
        {
            get {return storeNumber; }
            set { storeNumber = StoreValidation.FormatStoreNumber(value); }
        }

        private string storeType;
        public string StoreType 
        {
            get{return storeType;}
            set{storeType = StoreValidation.FormatName(value);}
        }

        private int products;
        public int Products 
        {
            get{return products;}
            set{products = StoreValidation.ValidateProducts(value);}
        }
    }
}
