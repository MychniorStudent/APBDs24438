using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Revenue
{
    public class GetRevenueDTO
    {
        public bool ForEntireCompany { get; set; }
        public Guid? SpecificProductId { get; set; }
        public string? SpecificCurrency { get; set; }
    }
}
