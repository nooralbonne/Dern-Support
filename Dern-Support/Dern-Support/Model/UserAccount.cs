using Dern_Support.Model;

public class UserAccount
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // Admin, Technician, Customer
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public Technician Technician { get; set; }
}