﻿// <auto-generated />
using System;
using Dern_Support.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dern_Support.Migrations
{
    [DbContext(typeof(DernSupportDbContext))]
    [Migration("20240913073054_RemoveRoleColumn")]
    partial class RemoveRoleColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Dern_Support.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Elm Street",
                            CompanyName = "N/A",
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1472),
                            CustomerType = "Individual",
                            Email = "alice.smith@example.com",
                            Name = "Alice Smith",
                            PhoneNumber = "987-654-3210",
                            UserId = 3
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "456 Oak Avenue",
                            CompanyName = "Business Corp",
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1477),
                            CustomerType = "Business",
                            Email = "info@businesscorp.com",
                            Name = "Business Corp",
                            PhoneNumber = "123-456-7890",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupportRequestId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupportRequestId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            FeedbackId = 1,
                            Comment = "Excellent service!",
                            CustomerId = 1,
                            Rating = 5,
                            SubmittedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1783),
                            SupportRequestId = 1
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Inventory", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<int>("ReorderThreshold")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Category = 1,
                            ItemName = "Screwdriver",
                            PricePerUnit = 19.99m,
                            QuantityInStock = 100,
                            ReorderThreshold = 10,
                            SupplierName = "ToolSupplier"
                        },
                        new
                        {
                            ItemId = 2,
                            Category = 0,
                            ItemName = "Resistor",
                            PricePerUnit = 0.10m,
                            QuantityInStock = 500,
                            ReorderThreshold = 50,
                            SupplierName = "ElectronicsSupplier"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<int?>("ActualCompletionTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EstimatedCompletionTime")
                        .HasColumnType("int");

                    b.Property<string>("JobStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScheduledDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupportRequestId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("SupportRequestId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1619),
                            EstimatedCompletionTime = 120,
                            JobStatus = "Scheduled",
                            Priority = "High",
                            ScheduledDate = new DateTime(2024, 9, 14, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1590),
                            SupportRequestId = 1,
                            TechnicianId = 1
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.JobHistory", b =>
                {
                    b.Property<int>("JobHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobHistoryId"));

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StatusChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TechnicianNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobHistoryId");

                    b.HasIndex("JobId");

                    b.ToTable("JobHistories");

                    b.HasData(
                        new
                        {
                            JobHistoryId = 1,
                            JobId = 1,
                            Status = "Pending",
                            StatusChangeDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1756),
                            TechnicianNote = "Awaiting parts"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.JobInventory", b =>
                {
                    b.Property<int>("JobInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobInventoryId"));

                    b.Property<DateTime>("DateUsed")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityUsed")
                        .HasColumnType("int");

                    b.HasKey("JobInventoryId");

                    b.HasIndex("ItemId");

                    b.HasIndex("JobId");

                    b.ToTable("JobInventories");
                });

            modelBuilder.Entity("Dern_Support.Model.KnowledgeBase", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("KnowledgeBases");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            Author = "John Doe",
                            Category = "Hardware",
                            Content = "Step-by-step guide to fix AC issues.",
                            DatePublished = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1723),
                            TechnicianId = 1,
                            Title = "How to fix a broken AC"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            Amount = 150.00m,
                            JobId = 1,
                            PaymentDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1685),
                            PaymentMethod = "CreditCard",
                            PaymentStatus = "Pending"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.SupportRequest", b =>
                {
                    b.Property<int>("SupportRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupportRequestId"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmittedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrgencyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupportRequestId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustomerId");

                    b.ToTable("SupportRequests");

                    b.HasData(
                        new
                        {
                            SupportRequestId = 1,
                            CustomerId = 1,
                            RequestDescription = "AC not working",
                            Status = "Submitted",
                            SubmittedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1558),
                            UrgencyLevel = "High"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("AvailabilityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TechnicianId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            AvailabilityStatus = "Available",
                            Email = "john.doe@example.com",
                            ExperienceYears = 5,
                            FullName = "John Doe",
                            PhoneNumber = "123-456-7890",
                            Specialization = "Electrical",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "admin",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UserAccount", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserAccounts");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(917),
                            Email = "admin@example.com",
                            PasswordHash = "hashedpassword",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(939),
                            Email = "tech1@example.com",
                            PasswordHash = "hashedpassword",
                            Role = "Technician",
                            Username = "tech1"
                        },
                        new
                        {
                            UserId = 3,
                            CreatedDate = new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(943),
                            Email = "customer1@example.com",
                            PasswordHash = "hashedpassword",
                            Role = "Customer",
                            Username = "customer1"
                        });
                });

            modelBuilder.Entity("Dern_Support.Model.Customer", b =>
                {
                    b.HasOne("UserAccount", "UserAccount")
                        .WithOne("Customer")
                        .HasForeignKey("Dern_Support.Model.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Dern_Support.Model.Feedback", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Dern_Support.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dern_Support.Model.SupportRequest", "SupportRequest")
                        .WithMany("Feedbacks")
                        .HasForeignKey("SupportRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SupportRequest");
                });

            modelBuilder.Entity("Dern_Support.Model.Job", b =>
                {
                    b.HasOne("Dern_Support.Model.SupportRequest", "SupportRequest")
                        .WithMany("Jobs")
                        .HasForeignKey("SupportRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dern_Support.Model.Technician", "Technician")
                        .WithMany("Jobs")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SupportRequest");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("Dern_Support.Model.JobHistory", b =>
                {
                    b.HasOne("Dern_Support.Model.Job", "Job")
                        .WithMany("JobHistories")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Dern_Support.Model.JobInventory", b =>
                {
                    b.HasOne("Dern_Support.Model.Inventory", "Inventory")
                        .WithMany("JobInventories")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dern_Support.Model.Job", "Job")
                        .WithMany("JobInventories")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Dern_Support.Model.KnowledgeBase", b =>
                {
                    b.HasOne("Dern_Support.Model.Technician", "Technician")
                        .WithMany("KnowledgeBaseArticles")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("Dern_Support.Model.Payment", b =>
                {
                    b.HasOne("Dern_Support.Model.Job", "Job")
                        .WithOne("Payment")
                        .HasForeignKey("Dern_Support.Model.Payment", "JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Dern_Support.Model.SupportRequest", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany("SupportRequests")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Dern_Support.Model.Customer", "Customer")
                        .WithMany("SupportRequests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Dern_Support.Model.Technician", b =>
                {
                    b.HasOne("UserAccount", "UserAccount")
                        .WithOne("Technician")
                        .HasForeignKey("Dern_Support.Model.Technician", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("SupportRequests");
                });

            modelBuilder.Entity("Dern_Support.Model.Customer", b =>
                {
                    b.Navigation("SupportRequests");
                });

            modelBuilder.Entity("Dern_Support.Model.Inventory", b =>
                {
                    b.Navigation("JobInventories");
                });

            modelBuilder.Entity("Dern_Support.Model.Job", b =>
                {
                    b.Navigation("JobHistories");

                    b.Navigation("JobInventories");

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("Dern_Support.Model.SupportRequest", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Dern_Support.Model.Technician", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("KnowledgeBaseArticles");
                });

            modelBuilder.Entity("UserAccount", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("Technician")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}