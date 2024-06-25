using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Subscription
{
    public class PayForSubscriptionDTO
    {
        public Guid IdSubscription { get; set; }
        public decimal Amount { get; set; }
    }
}
