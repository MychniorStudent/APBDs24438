using MedicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicApp.Contexts
{
    public class MedicDbContext : DbContext
    {
        public MedicDbContext() { }
        public MedicDbContext(DbContextOptions options) : base(options) { }



        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> PrescriptionsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24438;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(m => new { m.IdMedicament, m.IdPrescription });
        }
    }
}
