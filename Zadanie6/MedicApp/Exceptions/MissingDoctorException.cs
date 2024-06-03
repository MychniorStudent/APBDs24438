namespace MedicApp.Exceptions
{
    public class MissingDoctorException : Exception
    {
        public MissingDoctorException()
        {
        }

        public MissingDoctorException(string message)
            : base(message)
        {
        }

        public MissingDoctorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
