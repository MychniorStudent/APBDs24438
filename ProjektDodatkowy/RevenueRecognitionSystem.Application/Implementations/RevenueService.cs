using RevenueRecognitionSystem.Application.Interfaces;
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
        private readonly IConcurrencyService _concurenctyService;

        public RevenueService(ISoftwareSystemRepository softwareSystemRepository, IConcurrencyService concurrencyService)
        {
            _softwareSystemRepository = softwareSystemRepository;
            _concurenctyService = concurrencyService;
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
                if(result.EntireCompanyRevenue.HasValue)
                    result.EntireCompanyRevenue = _concurenctyService.GetExchangedCurrenty(result.EntireCompanyRevenue.Value, request.SpecificCurrency);

                if (result.SpecifiedProductRevenue.HasValue)
                    result.SpecifiedProductRevenue = _concurenctyService.GetExchangedCurrenty(result.SpecifiedProductRevenue.Value, request.SpecificCurrency);
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
                if (result.EntireCompanyRevenue.HasValue)
                    result.EntireCompanyRevenue = _concurenctyService.GetExchangedCurrenty(result.EntireCompanyRevenue.Value, request.SpecificCurrency);

                if (result.SpecifiedProductRevenue.HasValue)
                    result.SpecifiedProductRevenue = _concurenctyService.GetExchangedCurrenty(result.SpecifiedProductRevenue.Value, request.SpecificCurrency);
            }
            return result;
        }
    }
}
