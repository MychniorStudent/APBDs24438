namespace RevenueRecognitionSystem.Domain.Models.Client
{
    public class CompanyClient : BaseClient
    {
        internal CompanyClient(string Adress, string Email, string CompanyName, int KRS)
        {
            Id = Guid.NewGuid();
            this.Adress = Adress;
            this.Email = Email;
            this.CompanyName = CompanyName;
            this.KRS = KRS;
        }
        private CompanyClient()
        {}
        public string CompanyName { get; private set; }
        public int KRS { get; private set; }

        public static CompanyClient CreateNewCompanyClient(string Adress, string Email, string CompanyName, int KRS)
        {
            return new CompanyClient(Adress,Email,CompanyName,KRS);
        }
        public void Edit(string? newAdress, string? newEmail, string? newCompanyName)
        {
            this.Adress = newAdress == null ? this.Adress : newAdress;
            this.Email = newEmail == null ? this.Email : newEmail;
            this.CompanyName = newCompanyName == null ? this.CompanyName : newCompanyName;
        }
    }
}
