namespace RevenueRecognitionSystem.Domain.Models.SoftwareLicense
{
    public class Update
    {
        public Guid Id { get; private set; }
        public string UpdateDescription { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public Guid IdSoftware { get; private set; }
        public SoftwareSystem SoftwareSystem { get; private set; }
    }
}
