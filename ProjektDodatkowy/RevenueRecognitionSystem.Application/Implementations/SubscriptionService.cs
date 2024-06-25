using RevenueRecognitionSystem.Domain.DTOs.Subscription;
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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISoftwareSystemRepository _softwareSystemRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IBaseClientRepository _baseClientRepository;
        public SubscriptionService(IUnitOfWork unitOfWork,
            ISubscriptionRepository subscriptionRepository,
            ISoftwareSystemRepository softwareSystemRepository,
            IDiscountRepository discountRepository,
            IBaseClientRepository baseClientRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
            _softwareSystemRepository = softwareSystemRepository;
            _discountRepository = discountRepository;
            _baseClientRepository = baseClientRepository;
        }

        public void BuySubscription(BuySubscriptionDTO request)
        {
            BaseClient client = _baseClientRepository.GetClientById(request.IdClient);

            SoftwareSystem software = _softwareSystemRepository.GetSoftwareSystemById(request.IdSoftware);

            Discount? discountToApply = _discountRepository.GetCurrentAvaliableDiscounts()
                .Where(x => x.Offer == Domain.Enums.DiscountOffer.Subscription)
                .OrderByDescending(x => x.Value).FirstOrDefault();

           _subscriptionRepository.Add(Subscription.Create(request.Name, request.RenewalPeriod, request.Price, request.DateTimeSubscriptionStart, request.DateTimeSubscriptionEnd, software, client, discountToApply));
            _unitOfWork.Complete();
        }

        public void PayForSubscription(PayForSubscriptionDTO request)
        {
            Subscription subscription = _subscriptionRepository.GetSubscriptionById(request.IdSubscription);
            try
            {
                subscription.Pay(request.Amount);
            }
            catch (SubscriptionCancelledException ex) 
            {
                _unitOfWork.Complete();
            }
            
            
            _unitOfWork.Complete();
        }
    }
}
