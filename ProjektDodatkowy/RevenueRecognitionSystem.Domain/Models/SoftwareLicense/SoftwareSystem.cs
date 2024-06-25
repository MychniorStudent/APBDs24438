namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class SoftwareSystem
    {
        private SoftwareSystem(string Name, string Description, string Version, string Category)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Version = Version;
            this.Category = Category;
        }
        private SoftwareSystem()
        {
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Version { get; private set; }
        public string Category { get; private set; }

        public IReadOnlyCollection<Contract> Contracts => _contracts;
        private readonly List<Contract> _contracts = new List<Contract>();

        public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions;
        private readonly List<Subscription> _subscriptions = new List<Subscription>();
        public IReadOnlyCollection<Update> SoftwareUpdates => _softwareUpdates;
        private readonly List<Update> _softwareUpdates = new List<Update>();

        public static SoftwareSystem Create (string Name, string Description, string Version, string Category)
        {
            return new SoftwareSystem(Name, Description, Version, Category);
        }

        public decimal CalculateRevenue()
        {
            decimal result = 0;

            result = _contracts.Where(x => x.IsFinalized).Sum(s => s.TotalPrice);

            _subscriptions.ForEach(subscription =>
            {
                result += subscription.SubPayments.Sum(p=>p.PaymentValue);
            });
            return result;
        }

        public decimal CalculatePredictedRevenue()
        {
            decimal result = 0;
            result = _contracts.Sum(x => x.TotalPrice);
            _subscriptions.ForEach(subscription =>
            {
                result += subscription.CalculatePredictedRevenue();
            });

            return result;
        }
    }
}
