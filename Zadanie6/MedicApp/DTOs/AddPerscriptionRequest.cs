namespace MedicApp.DTOs
{
    public class AddPerscriptionRequest
    {
        public PatientDTO Patient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<MedicamentPrescriptionDTO> Medicaments { get; set; }

    }
}
