using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ClientAlreadyHasSystemException : RevenueException
    {
        public ClientAlreadyHasSystemException() : base() {}
        public ClientAlreadyHasSystemException(string message) : base(message){}
    }
}
