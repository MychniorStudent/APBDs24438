using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Exceptions
{
    public class IncorrectAmountOfMoney : RevenueException
    {
        public IncorrectAmountOfMoney() : base()
        {
            
        }
        public IncorrectAmountOfMoney(string message) : base(message)
        {
            
        }
    }
}
