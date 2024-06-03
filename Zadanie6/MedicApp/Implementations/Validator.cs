using MedicApp.DTOs;
using MedicApp.Interfaces;

namespace MedicApp.Implementations
{
    public class Validator : IValidator
    {
        public bool validDueDateWithDate(DateTime dueData, DateTime date)
        {
            if (dueData >= date)
                return true;

            return false;   
        }

        public bool validMedsCount(List<MedicamentPrescriptionDTO> data)
        {
            if(data.Count() > 10)
                return false;

            return true;
        }
    }
}
