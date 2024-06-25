using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ContractAlreadyFinalized : RevenueException
    {
        public ContractAlreadyFinalized() : base() { }
        public ContractAlreadyFinalized(string message) : base(message) { }
    }
}
