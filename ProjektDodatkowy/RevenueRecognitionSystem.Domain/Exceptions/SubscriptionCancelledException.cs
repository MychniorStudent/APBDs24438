using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class SubscriptionCancelledException : RevenueException
    {
        public SubscriptionCancelledException() : base() { }
    
        public SubscriptionCancelledException(string message) : base(message) { } 
    }
}
