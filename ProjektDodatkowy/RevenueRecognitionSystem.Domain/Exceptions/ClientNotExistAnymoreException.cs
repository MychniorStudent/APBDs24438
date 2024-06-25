using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class ClientNotExistAnymoreException : RevenueException
    {
        public ClientNotExistAnymoreException() : base() { }
        public ClientNotExistAnymoreException(string message) : base(message) { }
    }
}
