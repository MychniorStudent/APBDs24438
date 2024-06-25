using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Contract
{
    public class CreateContractDTO
    {
        public Guid IdSoftware { get; set; }
        public Guid IdClient { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal Price { get; set; }
        public int? AdditionalYearsOfSupport { get; set; }
    }
}
