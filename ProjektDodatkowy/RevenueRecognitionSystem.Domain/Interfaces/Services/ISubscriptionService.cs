using RevenueRecognitionSystem.Domain.DTOs.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Services
{
    public interface ISubscriptionService
    {
        void BuySubscription(BuySubscriptionDTO request);
        void PayForSubscription(PayForSubscriptionDTO request);
    }
}
