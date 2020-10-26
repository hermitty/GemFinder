namespace GemFinder.Identity.Exceptions
{
    public class InvalidPasswordException : AppException
    {
        public override string Code { get; } = "invalid_password";

        public InvalidPasswordException() : base($"Invalid password.")
        {
        }
    }
}