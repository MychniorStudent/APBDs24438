namespace MedicApp.Exceptions
{
    public class MissingMedicamentException : Exception
    {
        public MissingMedicamentException()
        {
        }

        public MissingMedicamentException(string message)
            : base(message)
        {
        }

        public MissingMedicamentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
