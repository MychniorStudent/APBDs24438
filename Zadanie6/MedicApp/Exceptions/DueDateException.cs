namespace MedicApp.Exceptions
{
    public class DueDateException : Exception
    {
        public DueDateException()
        {
        }

        public DueDateException(string message)
            : base(message)
        {
        }

        public DueDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
