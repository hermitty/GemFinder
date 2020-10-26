namespace GemFinder.Identity.Exceptions
{
    public class InvalidEmailException : AppException
    {
        public override string Code { get; } = "invalid_email";

        public InvalidEmailException(string email) : base($"Invalid email: {email}.")
        {
        }
    }
}