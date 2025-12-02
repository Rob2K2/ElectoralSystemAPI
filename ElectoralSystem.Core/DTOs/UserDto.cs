namespace ElectoralSystem.API.Core.DTOs
{
    public class UserDto
    {

        public string FullName { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
