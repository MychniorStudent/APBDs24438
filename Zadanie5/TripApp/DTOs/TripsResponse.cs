using TripApp.Models;

namespace TripApp.DTOs
{
    public class TripsResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
       public List<CountryInfoDTO> Countries { get; set; }
       public List<ClientInfoDTO> Clients { get; set; }
    }
}
