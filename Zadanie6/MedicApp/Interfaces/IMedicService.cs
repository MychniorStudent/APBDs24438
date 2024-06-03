using MedicApp.DTOs;
using MedicApp.Models;

namespace MedicApp.Interfaces
{
    public interface IMedicService
    {
        public Task<bool> AddPerscription(AddPerscriptionRequest request);
        public Task<Patient> GetPatientById(int patientId);
        public Task<Patient> AddPatient(Patient patient);
        public Task<Medicament> GetMedicamentById(int medicamentId);
        public Task<GetPatientDataResponse> GetPatientDataById(int patientId);
    }
}
