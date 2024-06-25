using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class SubscriptionAlreadyPaid : RevenueException
    {
        public SubscriptionAlreadyPaid() : base()
        {

        }
        public SubscriptionAlreadyPaid(string message) : base(message)
        {

        }
    }
}
