using LegacyApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Implementations
{
    public class Validator : IValidator
    {
        public bool isEmailValid(string email)
        {
            if(!email.Contains("@") && !email.Contains(".")) 
            {
                return false;
            }
            return true;
        }

        public bool isNameCorrect(string name)
        {
            if(string.IsNullOrEmpty(name))
                return false;
            return true;
        }

        public bool isOldEnough(DateTime birthDate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            return true;
        }
    }
}
