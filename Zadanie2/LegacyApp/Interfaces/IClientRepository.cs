using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegacyApp.Model;

namespace LegacyApp.Interfaces
{
    public interface IClientRepository
    {
       public Client GetById(int clientId);
       public void setCreditLimitForUserByClient(User user, Client client);
    }
}
