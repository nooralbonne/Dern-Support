namespace Dern_Support.Model.DTO
{
    public class UserAccountDto
    {
        //Purpose: Represents the user’s account details.
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
