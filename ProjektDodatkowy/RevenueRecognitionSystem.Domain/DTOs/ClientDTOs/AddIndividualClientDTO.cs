namespace RevenueRecognitionSystem.Domain.DTOs.ClientDTOs
{
    public class AddIndividualClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PESEL { get; set; }
    }
}
