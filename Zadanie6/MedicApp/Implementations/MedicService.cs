using MedicApp.Contexts;
using MedicApp.DTOs;
using MedicApp.Exceptions;
using MedicApp.Interfaces;
using MedicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicApp.Implementations
{
    public class MedicService : IMedicService
    {
        MedicDbContext _dbContext;
        IValidator _validator;
        public MedicService(MedicDbContext dbContext, IValidator validator)
        {
            _validator = validator;
            _dbContext = dbContext;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            _dbContext.Patients.AddAsync(patient);
            _dbContext.SaveChangesAsync();//Async();
            return patient;
        }

        public async Task<bool> AddPerscription(AddPerscriptionRequest request)
        {
            //throw new NotImplementedException();
            Patient patient = await GetPatientById(request.Patient.IdPatient);

            if(patient == null )
            {
                patient = await AddPatient(new Patient {  IdPatient = request.Patient.IdPatient,
                                                    FirstName = request.Patient.FirstName,
                                                    LastName = request.Patient.LastName,
                                                    Birthdate = request.Patient.Birthdate
                                                    });

            }



            if (!_validator.validMedsCount(request.Medicaments))
                throw new MedicamentCountException($"Zbyt duza ilosc lekow, maks 10 obecnie {request.Medicaments.Count}");

            if(!_validator.validDueDateWithDate(request.DueDate,request.Date))
                throw new DueDateException($"DueDate: {request.DueDate} wcześniej niż Date{request.Date}");

            Doctor doctor = GetDoctorById(request.IdDoctor);

            if (doctor == null)
                throw new MissingDoctorException("Nie ma takiego doktora w bazie");



            Dictionary<int, MedicamentPrescriptionDetails> meds = new Dictionary<int, MedicamentPrescriptionDetails>();
            
            foreach (var med in request.Medicaments)
            {
                Medicament medToAdd = await GetMedicamentById(med.IdMedicament);
                if (medToAdd == null)
                    throw new MissingMedicamentException("Brak leku w bazie");
                meds.Add(medToAdd.IdMedicament, new MedicamentPrescriptionDetails
                {
                    medDTO = med,
                    medicamentDetailed = medToAdd
                });
            }

            Prescription prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                Patient = patient,
                Doctor = doctor,
            };

            _dbContext.Prescriptions.Add(prescription);
            foreach (var med in meds)
            {
                _dbContext.PrescriptionsMedicaments.Add(new Prescription_Medicament
                {
                    Medicament = med.Value.medicamentDetailed,
                    Prescription = prescription,
                    Dose = med.Value.medDTO.Dose,
                    Details = med.Value.medDTO.Details
                });
            }
           await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Medicament> GetMedicamentById(int medicamentId)
        {
            return await _dbContext.Medicaments.FirstOrDefaultAsync(x => x.IdMedicament == medicamentId);
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(x => x.IdPatient == patientId);
        }

        public async Task<GetPatientDataResponse> GetPatientDataById(int patientId)
        {
            GetPatientDataResponse result = new GetPatientDataResponse();

            Patient patient = await GetPatientById(patientId);
            result.IdPatient = patient.IdPatient;
            result.FirstName = patient.FirstName;
            result.LastName = patient.LastName;
            result.Prescriptions = GetPresciptionsDataByClientId(patientId);
            //datebirth

            return result;
        }

        public Doctor GetDoctorById(int doctorId)
        {
          return _dbContext.Doctors.FirstOrDefault(x=>x.IdDoctor == doctorId);
        }

        public List<PrescriptionDTO> GetPresciptionsDataByClientId(int clientId)
        {
            List<PrescriptionDTO> result = _dbContext.Prescriptions
                .Where(x => x.Patient.IdPatient == clientId)
                .Select(x => new PrescriptionDTO
                {
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Doctor = new DoctorDTO
                    {
                        DoctorId = x.Doctor.IdDoctor,
                        FirstName = x.Doctor.FirstName
                    },
                    IdPresciption = x.IdPrescription,
                    Medicaments = _dbContext.PrescriptionsMedicaments
                                   .Where(d => d.IdPrescription == x.IdPrescription)
                                   .Select(f =>
                                   new MedicamentDTO
                                   {
                                       IdMedicament = f.Medicament.IdMedicament,
                                       Name = f.Medicament.Name,
                                       Dose = f.Dose,
                                       Description = f.Medicament.Description,
                                       Details = f.Details
                                   }).ToList()
                }).OrderBy(o=>o.DueDate).ToList();

            return result;
        }
    }
}
