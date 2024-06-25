using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Contract
{
    public class PayForContractDTO
    {
        public Guid IdContract { get; set; }
        public decimal Amount { get; set; }
    }
}
