using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    public class UserViewModel
    {
        private string encoded_password;


        public string GetId(int id)
        {
            if (id == 0)
                return "abc";
            else if (id == 4)
                return "xyz";
            else
                return "kkk";
        }
        public string EncodePassword(string password)
        {
            if (password == null || password.Length == 0)
            {
                throw new ValidationException("Password is empty");
            }
            else
            {
                // do the encoding
                encoded_password = "&&abc%%";
                return encoded_password;
            }
        }

        public bool TestPassword(string passwordText)
        {
            //Assumes that special characters are anything except upper and lower case letters and digits
            //Assumes that ASCII is being used (not suitable for many languages)

            int letters = 0;
            int digits = 0;
            int specialCharacters = 0;
            int minimumLength = 5;
            int maximumLength = 12;
            int minimumNumbers = 1;
            int minchars = 1;
            int minimumSpecialCharacters = 1;

            //Make sure there are enough total characters
            if (passwordText.Length < minimumLength)
            {
                
                return false;
            }
            //Make sure there are enough total characters
            if (passwordText.Length > maximumLength)
            {
            
                return false;
            }

            foreach (var ch in passwordText)
            {
                if (char.IsLetter(ch)) letters++; //increment letters
                if (char.IsDigit(ch)) digits++; //increment digits

                //Test for only letters and numbers...
                if (!((ch > 47 && ch < 58) || (ch > 64 && ch < 91) || (ch > 96 && ch < 123)))
                {
                    specialCharacters++;
                }
            }

            //Make sure there are enough digits
            if (digits < minimumNumbers)
            {
               
                return false;
            }

            if(letters < minchars)
            {
                return false;
            }
            //Make sure there are enough special characters -- !(a-zA-Z0-9)
            if (specialCharacters < minimumSpecialCharacters)
            {
               
                return false;
            }

            return true;
        }


    }
}
