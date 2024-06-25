using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class RevenueException : Exception
    {
        public RevenueException() : base() {}
        public RevenueException(string message) : base(message)  {}
    }
}
