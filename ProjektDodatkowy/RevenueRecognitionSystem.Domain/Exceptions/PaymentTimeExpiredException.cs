using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class PaymentTimeExpiredException : RevenueException
    {
        public PaymentTimeExpiredException() : base() { }
        public PaymentTimeExpiredException(string message) : base(message) { }
    }
}
