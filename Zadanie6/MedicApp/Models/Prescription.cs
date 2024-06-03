using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicApp.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        [ForeignKey("IdPatient")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor Doctor { get; set;}

    }
}
