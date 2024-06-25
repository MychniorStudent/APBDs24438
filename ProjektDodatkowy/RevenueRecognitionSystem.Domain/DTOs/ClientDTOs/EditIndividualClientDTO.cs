namespace RevenueRecognitionSystem.Domain.DTOs.ClientDTOs
{
    public class EditIndividualClientDTO
    {
        public Guid id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
