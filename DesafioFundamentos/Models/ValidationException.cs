namespace DesafioFundamentos.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(string error) : base(error) { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new ArgumentException(message);
            }
        }
    }
}