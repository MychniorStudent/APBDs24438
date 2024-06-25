using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Application.Interfaces
{
    public interface IConcurrencyService
    {
        decimal GetExchangedCurrenty(decimal amount, string currency );
    }
}
