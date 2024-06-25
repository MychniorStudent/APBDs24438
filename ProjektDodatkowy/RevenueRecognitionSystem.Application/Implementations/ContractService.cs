using RevenueRecognitionSystem.Domain.DTOs.Contract;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.Client;
using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Application.Implementations
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContractRepository _contractRepository;
        private readonly ISoftwareSystemRepository _softwareSystemRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IBaseClientRepository _baseClientRepository;
        public ContractService(IUnitOfWork unitOfWork,
            IContractRepository contractRepository,
            ISoftwareSystemRepository softwareSystemRepository,
            IDiscountRepository discountRepository,
            IBaseClientRepository baseClientRepository)
        {
            _unitOfWork = unitOfWork;
            _contractRepository = contractRepository;
            _softwareSystemRepository = softwareSystemRepository;
            _discountRepository = discountRepository;
            _baseClientRepository = baseClientRepository;
        }

        public void CreateContract(CreateContractDTO requestData)
        {
            

            BaseClient client = _baseClientRepository.GetClientById(requestData.IdClient);

            SoftwareSystem software = _softwareSystemRepository.GetSoftwareSystemById(requestData.IdSoftware);

            Discount? discountToApply = _discountRepository.GetCurrentAvaliableDiscounts()
                .Where(x=>x.Offer == Domain.Enums.DiscountOffer.Upfront)
                .OrderByDescending(x=>x.Value).FirstOrDefault();

            _contractRepository.Add(Contract.Create(requestData.ContractStartDate, requestData.ContractEndDate, requestData.Price, software, client, discountToApply, requestData.AdditionalYearsOfSupport.Value));

            _unitOfWork.Complete();
        }

        public decimal PayForContract(PayForContractDTO request)
        {
            Contract contract = _contractRepository.GetContractById(request.IdContract);
            decimal leftToPay = 0;
            try
            {
                leftToPay = contract.Pay(request.Amount);
            }catch(PaymentTimeExpiredException ex)
            {
                _unitOfWork.Complete();
                throw;
            }
            _unitOfWork.Complete();

            return leftToPay;
        }
    }
}
