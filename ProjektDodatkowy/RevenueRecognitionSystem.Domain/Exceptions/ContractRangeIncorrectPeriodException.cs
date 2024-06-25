using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ContractRangeIncorrectPeriodException : RevenueException
    {
        public ContractRangeIncorrectPeriodException() : base() { }                        
        public ContractRangeIncorrectPeriodException(string message) : base(message) { }             
    }
}
