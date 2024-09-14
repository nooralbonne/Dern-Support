namespace Dern_Support.Model.DTO
{
    public class RegisterdUserDto
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }  // Add this field
        public string? LastName { get; set; }   // Add this field
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<string> Roles { get; set; }
    }
}
