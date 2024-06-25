using RevenueRecognitionSystem.Domain.Enums;

namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class Discount
    {
        public Guid Id { get;  set; }
        public string  Name { get;  set; }
        public DiscountOffer Offer { get;  set; }
        public DateTime DateFrom { get;  set; }
        public DateTime DateTo { get;  set; }
        public int Value { get;  set; }
    }
}
