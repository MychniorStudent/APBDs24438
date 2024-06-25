using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class IncorrectSubscriptionPeriodException : RevenueException
    {
        public IncorrectSubscriptionPeriodException() : base()
        {
            
        }
        public IncorrectSubscriptionPeriodException(string message) : base(message)
        {
            
        }
    }
}
