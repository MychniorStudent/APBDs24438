namespace TripApp.DTOs
{
    public class ClientTripAssignDTO
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string email { get; set; }
            public string Telephone { get; set; }
            public string PESEL { get; set; }
            public int IdTrip { get; set; }
            public string TripName { get; set; }
            public DateTime? PaymentDate { get; set; }

    }
}
