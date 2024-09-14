using Dern_Support.Model;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Optional FirstName and LastName
    public string? FirstName { get; set; } // Nullable
    public string? LastName { get; set; }  // Nullable

    // Optional: Define navigation properties if needed
    public List<SupportRequest> SupportRequests { get; set; }
    public List<Feedback> Feedbacks { get; set; }
}
