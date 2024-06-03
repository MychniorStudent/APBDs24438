using MedicApp.Models;

namespace MedicApp.DTOs
{
    public class MedicamentPrescriptionDetails
    {
        public MedicamentPrescriptionDTO medDTO { get; set; }
        public Medicament medicamentDetailed { get; set; }
    }
}
