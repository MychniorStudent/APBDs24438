using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ContractOverpaidException : RevenueException
    {
        public ContractOverpaidException() : base() {}

        public ContractOverpaidException(string message) : base(message) {}
    }
}
