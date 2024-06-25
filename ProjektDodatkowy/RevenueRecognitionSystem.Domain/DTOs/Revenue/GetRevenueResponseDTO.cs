using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Revenue
{
    public class GetRevenueResponseDTO
    {
        public decimal? EntireCompanyRevenue { get; set; }
        public decimal? SpecifiedProductRevenue { get; set; }
    }
}
