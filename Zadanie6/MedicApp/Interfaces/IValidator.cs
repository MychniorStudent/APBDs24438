using MedicApp.DTOs;

namespace MedicApp.Interfaces
{
    public interface IValidator
    {
        bool validMedsCount(List<MedicamentPrescriptionDTO> data);
        bool validDueDateWithDate(DateTime dueData, DateTime date);
    }
}
