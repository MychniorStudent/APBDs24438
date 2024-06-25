using RevenueRecognitionSystem.Domain.DTOs.Revenue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Services
{
    public interface IRevenueService
    {
        GetRevenueResponseDTO GetRevenue(GetRevenueDTO request);
        GetRevenueResponseDTO GetPredictedRevenue(GetRevenueDTO request);
    }
}
