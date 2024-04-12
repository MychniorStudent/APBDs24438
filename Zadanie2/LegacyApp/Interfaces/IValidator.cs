using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Interfaces
{
    public interface IValidator
    {
        bool isEmailValid(string email);
        bool isOldEnough(DateTime birthDate);
        bool isNameCorrect(string name);
    }
}
