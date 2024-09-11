using Dern_Support.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Data
{
    public class DernSupportDbContext : IdentityDbContext<ApplicationUser>
    {
        public DernSupportDbContext(DbContextOptions<DernSupportDbContext> options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<JobInventory> JobInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<UserAccount>().HasKey(u => u.UserId);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Technician>().HasKey(t => t.TechnicianId);
            modelBuilder.Entity<SupportRequest>().HasKey(sr => sr.SupportRequestId);
            modelBuilder.Entity<Job>().HasKey(j => j.JobId);
            modelBuilder.Entity<JobHistory>().HasKey(jh => jh.JobHistoryId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Feedback>().HasKey(f => f.FeedbackId);
            modelBuilder.Entity<KnowledgeBase>().HasKey(kb => kb.ArticleId);
            modelBuilder.Entity<Inventory>().HasKey(i => i.ItemId);
            modelBuilder.Entity<JobInventory>().HasKey(ji => ji.JobInventoryId);

            // Define relationships

            // UserAccount to Customer (One-to-One)
            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.UserAccount)
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserAccount to Technician (One-to-One)
            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.Technician)
                .WithOne(t => t.UserAccount)
                .HasForeignKey<Technician>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Technician to Job (One-to-Many)
            modelBuilder.Entity<Technician>()
                .HasMany(t => t.Jobs)
                .WithOne(j => j.Technician)
                .HasForeignKey(j => j.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            // Technician to KnowledgeBase (One-to-Many)
            modelBuilder.Entity<Technician>()
                .HasMany(t => t.KnowledgeBaseArticles)
                .WithOne(kb => kb.Technician)
                .HasForeignKey(kb => kb.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportRequest to Customer (Many-to-One)
            modelBuilder.Entity<SupportRequest>()
                .HasOne(sr => sr.Customer)
                .WithMany(c => c.SupportRequests)
                .HasForeignKey(sr => sr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportRequest to Job (One-to-Many)
            modelBuilder.Entity<SupportRequest>()
                .HasMany(sr => sr.Jobs)
                .WithOne(j => j.SupportRequest)
                .HasForeignKey(j => j.SupportRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportRequest to Feedback (One-to-Many)
            modelBuilder.Entity<SupportRequest>()
                .HasMany(sr => sr.Feedbacks)
                .WithOne(f => f.SupportRequest)
                .HasForeignKey(f => f.SupportRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job to JobHistory (One-to-Many)
            modelBuilder.Entity<Job>()
                .HasMany(j => j.JobHistories)
                .WithOne(jh => jh.Job)
                .HasForeignKey(jh => jh.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job to Payment (One-to-One)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Payment)
                .WithOne(p => p.Job)
                .HasForeignKey<Payment>(p => p.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            // Inventory to JobInventory (One-to-Many)
            modelBuilder.Entity<Inventory>()
                .HasMany(i => i.JobInventories)
                .WithOne(ji => ji.Inventory)
                .HasForeignKey(ji => ji.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job to JobInventory (One-to-Many)
            modelBuilder.Entity<Job>()
                .HasMany(j => j.JobInventories)
                .WithOne(ji => ji.Job)
                .HasForeignKey(ji => ji.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal properties
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Inventory>()
                .Property(i => i.PricePerUnit)
                .HasColumnType("decimal(18,2)");

            //===============================================
            // Seed data
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { UserId = 1, Username = "admin", PasswordHash = "hashedpassword", Role = "Admin", Email = "admin@example.com", CreatedDate = DateTime.Now },
                new UserAccount { UserId = 2, Username = "tech1", PasswordHash = "hashedpassword", Role = "Technician", Email = "tech1@example.com", CreatedDate = DateTime.Now },
                new UserAccount { UserId = 3, Username = "customer1", PasswordHash = "hashedpassword", Role = "Customer", Email = "customer1@example.com", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = 1, UserId = 2, FullName = "John Doe", Specialization = "Electrical", PhoneNumber = "123-456-7890", Email = "john.doe@example.com", ExperienceYears = 5, AvailabilityStatus = "Available" }
            );

          modelBuilder.Entity<Customer>().HasData(
    new Customer { CustomerId = 1, UserId = 3, Name = "Alice Smith", CustomerType = "Individual", Address = "123 Elm Street", PhoneNumber = "987-654-3210", Email = "alice.smith@example.com", CompanyName = "N/A", CreatedDate = DateTime.Now },
    new Customer { CustomerId = 2, UserId = 4, Name = "Business Corp", CustomerType = "Business", Address = "456 Oak Avenue", PhoneNumber = "123-456-7890", Email = "info@businesscorp.com", CompanyName = "Business Corp", CreatedDate = DateTime.Now }
);


            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { ItemId = 1, ItemName = "Screwdriver", Category = ItemCategory.Tool, QuantityInStock = 100, PricePerUnit = 19.99m, SupplierName = "ToolSupplier", ReorderThreshold = 10 },
                new Inventory { ItemId = 2, ItemName = "Resistor", Category = ItemCategory.SparePart, QuantityInStock = 500, PricePerUnit = 0.10m, SupplierName = "ElectronicsSupplier", ReorderThreshold = 50 }
            );

            modelBuilder.Entity<SupportRequest>().HasData(
                new SupportRequest { SupportRequestId = 1, CustomerId = 1, RequestDescription = "AC not working", UrgencyLevel = "High", Status = "Submitted", SubmittedDate = DateTime.Now, ResponseDate = null }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job { JobId = 1, SupportRequestId = 1, TechnicianId = 1, ScheduledDate = DateTime.Now.AddDays(1), Priority = "High", JobStatus = "Scheduled", EstimatedCompletionTime = 120, ActualCompletionTime = null, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = 1, JobId = 1, Amount = 150.00m, PaymentDate = DateTime.Now, PaymentMethod = "CreditCard", PaymentStatus = "Pending" }
            );

            modelBuilder.Entity<KnowledgeBase>().HasData(
                new KnowledgeBase { ArticleId = 1, Title = "How to fix a broken AC", Content = "Step-by-step guide to fix AC issues.", Category = "Hardware", DatePublished = DateTime.Now, Author = "John Doe", TechnicianId = 1 }
            );

            modelBuilder.Entity<JobHistory>().HasData(
                new JobHistory { JobHistoryId = 1, JobId = 1, Status = "Pending", StatusChangeDate = DateTime.Now, TechnicianNote = "Awaiting parts" }
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { FeedbackId = 1, SupportRequestId = 1, CustomerId = 1, Rating = 5, Comment = "Excellent service!", SubmittedDate = DateTime.Now }
            );

            //==========================================
            seedRoles(modelBuilder, "Admin", "create", "update", "delete");
            seedRoles(modelBuilder, "User", "update");
        }

        private void seedRoles(ModelBuilder modelBuilder, string roleName, params string[] permission)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            // add claims for the users
            // complete

            modelBuilder.Entity<IdentityRole>().HasData(role);
            //==========================================


            base.OnModelCreating(modelBuilder);
        }
    }
}
