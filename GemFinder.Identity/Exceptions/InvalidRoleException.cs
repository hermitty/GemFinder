namespace GemFinder.Identity.Exceptions
{
    public class InvalidRoleException : AppException
    {
        public override string Code { get; } = "invalid_role";

        public InvalidRoleException(string role) : base($"Invalid role: {role}.")
        {
        }
    }
}