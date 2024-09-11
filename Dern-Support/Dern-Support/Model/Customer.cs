namespace Dern_Support.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; } // Business, Individual
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; } // Nullable for business customers
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public UserAccount UserAccount { get; set; }
        public ICollection<SupportRequest> SupportRequests { get; set; }
    }
}
