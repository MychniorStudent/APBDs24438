using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //Repozytoria
        int Complete();
    }
}
