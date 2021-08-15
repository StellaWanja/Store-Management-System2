using System;
using System.Text.RegularExpressions; //use for Regex
using System.Linq;

namespace Management.Commons
{
    public class InputValidation
    {
        public static int accountInputValidity(string data)
        {
            bool isValid = Int32.TryParse(data, out int value);
            if (!isValid)
            {
                return -1;
            }
            else if(value < 0 || value > 2)
            {
                return -1;
            }
            return value;
        }

        public static int storeInputValidity(string data)
        {
            bool isValid = Int32.TryParse(data, out int value);
            if (!isValid)
            {
                return -1;
            }
            else if(value < 0 || value > 4)
            {
                return -1;
            }
            return value;
        }
    }
}