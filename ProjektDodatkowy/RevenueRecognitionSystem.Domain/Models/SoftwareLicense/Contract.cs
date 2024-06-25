using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Models.Client;
using System.Net.Sockets;

namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class Contract
    {
        internal Contract(DateTime StartDate, DateTime EndDate, decimal TotalPrice, decimal AmountToPay, SoftwareSystem Software, BaseClient Client, int YearsOfSupport)
        {
            if (!ValidateContractRange(StartDate, EndDate))
                throw new ContractRangeIncorrectPeriodException("Niedozwolona długość kontraktu");

            Id = Guid.NewGuid();
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.TotalPrice = TotalPrice;
            this.AmountToPay = AmountToPay;
            this.IdSoftware = Software.Id;
            this.SoftwareSystem = Software;
            this.Client = Client;
            this.IdClient = Client.Id;
            this.SoftwareSystem = Software;
            this.Client = Client;
            IsFinalized = false;
            IsCancelled = false;

        }

        private Contract (){}
        public Guid Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal AmountToPay { get; private set; }
        public bool IsFinalized { get; private set; }
        public bool IsCancelled { get; private set; }
        public int YearsOfSupport { get; private set; } 

        
        public Guid IdSoftware { get; private set; }
        public SoftwareSystem SoftwareSystem { get; private set; }


        public Guid IdClient { get; private set; }
        public BaseClient Client { get; private set; }

        public static Contract Create(DateTime StartDate, DateTime EndDate, decimal TotalPrice, SoftwareSystem Software, BaseClient Client, Discount? discount, int AdditionalYearsOfSupport = 0)
        {

            
            decimal discountValue = TotalPrice * ((decimal)discount.Value / 100);
            TotalPrice = TotalPrice - discountValue;


            if (Client.DeservePreviousClientDiscount())
                TotalPrice = TotalPrice - (TotalPrice * ((decimal)5 / 100));

            if (Client.CheckIfClientHasSoftware(Software))
                throw new ClientAlreadyHasSystemException($"Klient posiada już produkt {Software.Name}");

            TotalPrice += CalculateAdditionalCosts(AdditionalYearsOfSupport);
            return new Contract(StartDate, EndDate, TotalPrice, TotalPrice, Software, Client, AdditionalYearsOfSupport + 1);
        }

        private bool ValidateContractRange (DateTime StartDate, DateTime EndDate)
        {
            TimeSpan ContractRange = EndDate - StartDate;
            if (ContractRange.Days > 30 || ContractRange.Days < 3)
                return false;
            return true;
        }

        private static decimal CalculateAdditionalCosts(int? AdditionalYearsOfSupport)
        {
            if(AdditionalYearsOfSupport == null)
                return 0;
            return (decimal)AdditionalYearsOfSupport * 1000;
        }

        public decimal Pay (decimal amount)
        {
            if (IsFinalized)
                throw new ContractAlreadyFinalized("Kontrak został już sfinalizowany");

            if (IsCancelled)
                throw new ContractAlreadyCancelled("Kontrak został już anulowany");

            if (!CheckDTNowInContractRange())
            {
                IsCancelled = true;
                throw new PaymentTimeExpiredException("Czas płatności minął");
            }


            AmountToPay = AmountToPay - amount;

            if (AmountToPay < 0)
                throw new ContractOverpaidException("Nie można zapłacić więcej niż się należy");


            if (AmountToPay == 0)
                IsFinalized = true;

            return AmountToPay;
        }
        private bool CheckDTNowInContractRange()
        {
            if (DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate)
               return true;
            return false;
        }
    }
}
