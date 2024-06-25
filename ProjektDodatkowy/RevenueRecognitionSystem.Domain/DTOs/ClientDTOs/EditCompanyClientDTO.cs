namespace RevenueRecognitionSystem.Domain.DTOs.ClientDTOs
{
    public class EditCompanyClientDTO
    {
        public Guid id { get; set; }
        public string? CompanyName { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
    }
}
