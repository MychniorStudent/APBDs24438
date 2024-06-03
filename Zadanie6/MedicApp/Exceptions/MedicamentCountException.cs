namespace MedicApp.Exceptions
{
    public class MedicamentCountException : Exception
    {
        public MedicamentCountException()
        {
        }

        public MedicamentCountException(string message)
            : base(message)
        {
        }

        public MedicamentCountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
