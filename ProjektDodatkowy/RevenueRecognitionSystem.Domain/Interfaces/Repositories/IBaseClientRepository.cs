using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Repositories
{
    public interface IBaseClientRepository
    {
        BaseClient? GetClientById(Guid id);
    }
}
