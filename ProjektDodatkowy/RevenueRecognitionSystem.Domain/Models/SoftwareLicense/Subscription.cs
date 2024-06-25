using RevenueRecognitionSystem.Domain.Enums;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class Subscription
    {
        internal Subscription(string name, RenewalPeriod renewalPeriod, decimal price, DateTime startDate, DateTime endDate, SoftwareSystem softwareSystem, BaseClient client)
        {
            Id = Guid.NewGuid();
            Name = name;
            RenewalPeriod = renewalPeriod;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            IdSoftware = softwareSystem.Id;
            SoftwareSystem = softwareSystem;
            IdClient = client.Id;
            Client = client;
            IsCanceled = false;
        }

        private Subscription() {}

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public RenewalPeriod RenewalPeriod { get; private set; }
        public decimal Price { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Guid IdSoftware { get; private set; }
        public SoftwareSystem SoftwareSystem { get; private set; }
        public bool IsCanceled { get; private set; }


        public Guid IdClient { get; private set; }
        public BaseClient Client { get; private set; }

        public IReadOnlyCollection<SubPayment> SubPayments => _subPayments;
        internal readonly List<SubPayment> _subPayments = new List<SubPayment>();


        
        public static Subscription Create(string Name, RenewalPeriod RenewalPeriod, decimal Price, DateTime StartDate, DateTime EndDate, SoftwareSystem SoftwareSystem, BaseClient Client, Discount? discount)
        {
            if (!CheckIfSubPeriodIsValid(StartDate, EndDate))
                throw new IncorrectSubscriptionPeriodException("Niepoprawna długość subskrypcji");

            if(Client.DeservePreviousClientDiscount())
                Price = Price - (Price * ((decimal)5 / 100));


            Subscription subscription = new Subscription(Name, RenewalPeriod, Price, StartDate, EndDate, SoftwareSystem, Client);

            DateTime nowDt = DateTime.UtcNow;


            decimal FirstPaymentCost = Price;
            if (discount != null) {
                decimal discountValue = Price * ((decimal)discount.Value / 100);
                FirstPaymentCost = FirstPaymentCost - discountValue;
            }
            

            SubPayment FirstPayment = SubPayment.Create(nowDt, nowDt, RenewalPeriod == RenewalPeriod.Monthly? nowDt.AddMonths(1) : nowDt.AddYears(1), subscription, FirstPaymentCost);

            subscription._subPayments.Add(FirstPayment);


            return subscription;
        }

        public static bool CheckIfSubPeriodIsValid(DateTime StartTime, DateTime EndTime)
        {
            int MonthsInPeriod = ((EndTime.Year - StartTime.Year) * 12) + EndTime.Month - StartTime.Month;

            if(MonthsInPeriod < 1 || MonthsInPeriod > 24)
                return false;
            return true;
        }

        public void Pay(decimal amount)
        {
            //spawdzenie ile pieniażków przyszło
            if (amount != Price)
                throw new IncorrectAmountOfMoney("Niepoprawna ilość pieniążków");


            //sprawdzenie czy został opłacony poprzedni okres
            SubPayment LastPayment = _subPayments.OrderByDescending(x => x.EndDateTimePeriod).FirstOrDefault();


            if (LastPayment.EndDateTimePeriod.AddMonths((int)RenewalPeriod) < DateTime.UtcNow)
            {               
                IsCanceled = true;
                throw new SubscriptionCancelledException("Subskrypcja anulowana, opłata opóźniona");
            }


            if(LastPayment.StartDateTimePeriod <= DateTime.UtcNow && LastPayment.EndDateTimePeriod > DateTime.UtcNow) 
            {
                throw new SubscriptionAlreadyPaid("Subskrypcja została już opłacona za ten okres");
            }

            DateTime CurrentDTStamp = LastPayment.EndDateTimePeriod.AddDays(1);
            _subPayments.Add(SubPayment.Create(DateTime.UtcNow,CurrentDTStamp,CurrentDTStamp.AddMonths((int)RenewalPeriod),this,amount));


        }

        public decimal CalculatePredictedRevenue()
        {
            decimal result = 0;
            result = _subPayments.Sum(x=>x.PaymentValue);
            SubPayment LastPayment = _subPayments.OrderByDescending(x => x.EndDateTimePeriod).FirstOrDefault();

            int MonthsInPeriodRemain = ((EndDate.Year - LastPayment.EndDateTimePeriod.Year) * 12) + EndDate.Month - LastPayment.EndDateTimePeriod.Month;

            int PaymentsLeft = MonthsInPeriodRemain / (int)RenewalPeriod;

            result += PaymentsLeft * Price;
            return result;
        }
    }
}
