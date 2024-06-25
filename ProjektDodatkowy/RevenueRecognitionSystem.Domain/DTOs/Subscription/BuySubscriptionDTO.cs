using RevenueRecognitionSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs.Subscription
{
    public class BuySubscriptionDTO
    {
        public Guid IdClient { get; set; }
        public Guid IdSoftware { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public RenewalPeriod RenewalPeriod { get; set; }
        public DateTime DateTimeSubscriptionStart { get; set; }
        public DateTime DateTimeSubscriptionEnd { get; set; }
    }
}
