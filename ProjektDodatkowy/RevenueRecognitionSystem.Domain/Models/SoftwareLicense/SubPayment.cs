using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class SubPayment
    {
        internal SubPayment(DateTime payDateTime, DateTime startDateTimePeriod, DateTime endDateTimePeriod, Subscription subscription, decimal paymentValue)
        {
            Id = Guid.NewGuid();
            PayDateTime = payDateTime;
            StartDateTimePeriod = startDateTimePeriod;
            EndDateTimePeriod = endDateTimePeriod;
            IdSubscription = subscription.Id;
            Subscription = subscription;
            PaymentValue = paymentValue;
        }

        private SubPayment()
        {}
        public Guid Id { get; private set; }
        public DateTime PayDateTime { get; private set; }
        public DateTime StartDateTimePeriod { get; private set; }
        public DateTime EndDateTimePeriod { get; private set; }
        public decimal PaymentValue { get; set; }
        public Guid IdSubscription { get; private set; }
        public Subscription Subscription { get; private set; }

        public static SubPayment Create(DateTime payDateTime, DateTime startDateTimePeriod, DateTime EndDateTimePeriod, Subscription subscription, decimal? PaymentValue)
        {
            return new SubPayment(payDateTime,startDateTimePeriod,EndDateTimePeriod,subscription,PaymentValue.Value);
        }
    }
}
