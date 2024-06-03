using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicApp.Models
{
    public class Prescription_Medicament
    {
        [Key, Column(Order = 0)]
        public int IdMedicament { get; set; }
        public virtual Medicament Medicament { get; set; }
        [Key, Column(Order = 1)]
        public int IdPrescription { get; set; }
        public virtual Prescription Prescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
    }
}
