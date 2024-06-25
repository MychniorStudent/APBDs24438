using RevenueRecognitionSystem.Domain.Exceptions;
using System.Runtime.CompilerServices;

namespace RevenueRecognitionSystem.Domain.Models.Client
{
    public class IndividualClient : BaseClient
    {
        private IndividualClient(string FirstName, string LastName, string PhoneNumber, int PESEL, string Adress, string Email)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.PESEL = PESEL;
            this.Adress = Adress;
            this.Email = Email;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public int PESEL { get; private set; }
        public bool IsDeleted { get; private set; }
        public static IndividualClient CreateNewIndividualClient(string FirstName, string LastName, string PhoneNumber, int PESEL, string Adress, string Email)
        {
            return new IndividualClient(FirstName, LastName, PhoneNumber, PESEL, Adress, Email);
        }
        public void Remove()
        {
            FirstName = "#####";
            LastName = "#####";
            Email = "#####";
            Adress = "#####";
            PhoneNumber = "#####";
            PESEL = -1;
            IsDeleted = true;
        }
        public void Edit(string? newFirstName,string? newLastName, string? newPhoneNumber, string? newEmail, string? newAdress)
        {
            if (IsDeleted)
                throw new ClientNotExistAnymoreException("Klient jest usunięty z systemu, nie można edytować");
            this.FirstName = newFirstName == null ? this.FirstName : newFirstName;
            this.LastName = newLastName == null ? this.LastName : newLastName;
            this.PhoneNumber = newPhoneNumber == null ? this.PhoneNumber : newPhoneNumber;
            this.Adress = newAdress == null? this.Adress : newAdress;   
            this.Email = newEmail == null ? this.Email : newEmail;
        }
    }
}
