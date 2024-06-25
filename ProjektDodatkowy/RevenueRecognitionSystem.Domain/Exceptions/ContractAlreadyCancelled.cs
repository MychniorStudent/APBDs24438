using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ContractAlreadyCancelled : RevenueException
    {
        public ContractAlreadyCancelled() : base() { }
        public ContractAlreadyCancelled(string message) : base(message) { }
    }
}
