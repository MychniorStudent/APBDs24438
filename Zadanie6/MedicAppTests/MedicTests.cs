using MedicApp.DTOs;
using MedicApp.Exceptions;
using MedicApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAppTests
{
    public class MedicTests
    {
        IMedicService _mediicService;
        public MedicTests(IMedicService medicService)
        {
            _mediicService = medicService;
        }
        [Fact]
        public void Get_Patient_Data_Should_Return_Object_When_Patient_Exist ()
        {
            //Arrange
            int patientId = 1;
            //Act
            GetPatientDataResponse result;
            try
            {
                result = _mediicService.GetPatientDataById(patientId);
            }catch (Exception ex)
            {
                result = null;
            }

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void AddPerscription_Should_Throw_MissingMedicamentException_If_Medicament_Not_Found()
        {
            //Arrange
            AddPerscriptionRequest request = new AddPerscriptionRequest {
                    Patient = new PatientDTO { IdPatient = 1},
                    IdDoctor = 1,
                    Date = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(5),
                    Medicaments = new List<MedicamentPrescriptionDTO> { 
                        new MedicamentPrescriptionDTO {  IdMedicament = 500,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {  IdMedicament = 2,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5}
                    }
            };

            //Act

            var ex = Assert.Throws<MissingMedicamentException>(() => _mediicService.AddPerscription(request));

            //Assert
            Assert.IsType<MissingMedicamentException>(ex);
        }
        public void AddPerscription_Should_Throw_MedicamentCountException_If_Medicament_Count_Above_10()
        {
            //Arrange
            AddPerscriptionRequest request = new AddPerscriptionRequest
            {
                Patient = new PatientDTO { IdPatient = 1 },
                IdDoctor = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                Medicaments = new List<MedicamentPrescriptionDTO> {
                        new MedicamentPrescriptionDTO {  IdMedicament = 1,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {  IdMedicament = 2,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5},
                    }
            };

            //Act

            var ex = Assert.Throws<MedicamentCountException>(() => _mediicService.AddPerscription(request));

            //Assert
            Assert.IsType<MedicamentCountException>(ex);
        }
        public void AddPerscription_Should_Throw_DueDateException_If_DueDate_Earlier_Than_Date()
        {
            //Arrange
            AddPerscriptionRequest request = new AddPerscriptionRequest
            {
                Patient = new PatientDTO { IdPatient = 1 },
                IdDoctor = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(-5),
                Medicaments = new List<MedicamentPrescriptionDTO> {
                        new MedicamentPrescriptionDTO {  IdMedicament = 1,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {  IdMedicament = 2,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5}
                    }
            };

            //Act

            var ex = Assert.Throws<DueDateException>(() => _mediicService.AddPerscription(request));

            //Assert
            Assert.IsType<DueDateException>(ex);
        }
        public void AddPerscription_Should_Throw_MissingDoctorException_If_Doctor_Not_Found()
        {
            //Arrange
            AddPerscriptionRequest request = new AddPerscriptionRequest
            {
                Patient = new PatientDTO { IdPatient = 1 },
                IdDoctor = 500,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(-5),
                Medicaments = new List<MedicamentPrescriptionDTO> {
                        new MedicamentPrescriptionDTO {  IdMedicament = 1,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {  IdMedicament = 2,Details="",Dose=5},
                        new MedicamentPrescriptionDTO {IdMedicament = 1, Details = "", Dose = 5}
                    }
            };

            //Act

            var ex = Assert.Throws<MissingDoctorException>(() => _mediicService.AddPerscription(request));

            //Assert
            Assert.IsType<MissingDoctorException>(ex);
        }
    }
}
