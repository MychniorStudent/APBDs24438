using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Interfaces
{
    public interface IUserService
    {
        bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId);

    }
}
