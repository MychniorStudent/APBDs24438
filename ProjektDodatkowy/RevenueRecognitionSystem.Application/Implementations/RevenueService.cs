using RevenueRecognitionSystem.Domain.DTOs.Revenue;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Application.Implementations
{
    public class RevenueService : IRevenueService
    {

        private readonly ISoftwareSystemRepository _softwareSystemRepository;

        public RevenueService(ISoftwareSystemRepository softwareSystemRepository)
        {
            _softwareSystemRepository = softwareSystemRepository;

        }
        public GetRevenueResponseDTO GetPredictedRevenue(GetRevenueDTO request)
        {
            GetRevenueResponseDTO result = new GetRevenueResponseDTO();
            if (request.SpecificProductId != null)
            {
                result.SpecifiedProductRevenue = _softwareSystemRepository.GetSoftwareSystemById(request.SpecificProductId.Value).CalculatePredictedRevenue();
            }
            if(request.ForEntireCompany)
            {
                decimal EnitreAmount = 0;
                var products = _softwareSystemRepository.GetAll();
                products.ForEach(x=>{

                    EnitreAmount += x.CalculatePredictedRevenue();
                });
                result.EntireCompanyRevenue = EnitreAmount;
            }
            if(request.SpecificCurrency != null)
            {

            }
            return result;
        }

        public GetRevenueResponseDTO GetRevenue(GetRevenueDTO request)
        {
            GetRevenueResponseDTO result = new GetRevenueResponseDTO();
            if (request.SpecificProductId != null)
            {
                result.SpecifiedProductRevenue = _softwareSystemRepository.GetSoftwareSystemById(request.SpecificProductId.Value).CalculateRevenue();
            }
            if (request.ForEntireCompany)
            {
                decimal EnitreAmount = 0;
                var products = _softwareSystemRepository.GetAll();
                products.ForEach(x => {

                    EnitreAmount += x.CalculateRevenue();
                });
                result.EntireCompanyRevenue = EnitreAmount;
            }
            if (request.SpecificCurrency != null)
            {

            }
            return result;
        }
    }
}
