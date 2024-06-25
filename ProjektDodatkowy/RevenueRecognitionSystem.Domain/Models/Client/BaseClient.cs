using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;

namespace RevenueRecognitionSystem.Domain.Models.Client
{
    public class BaseClient
    {
        public Guid Id { get; internal set; }
        public string Adress { get; internal set; }
        public string Email { get; internal set; }

        public IReadOnlyCollection<Contract> Contracts => _contracts;
        internal readonly List<Contract> _contracts = new List<Contract>();

        public bool DeservePreviousClientDiscount() 
        {
            if (_contracts.Any())
                return true;
            return false;
        }
        public bool CheckIfClientHasSoftware(SoftwareSystem software)
        {
            if(Contracts.Any(x=>x.IdSoftware == software.Id))
                return true;
            return false;
        }
    }
}
