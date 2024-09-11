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
    [Migration("20240909143146_CreateOtherTables")]
    partial class CreateOtherTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                });

            modelBuilder.Entity("Dern_Support.Model.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

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

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupportRequestId");

                    b.ToTable("Feedbacks");
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
                });

            modelBuilder.Entity("Dern_Support.Model.SupportRequest", b =>
                {
                    b.Property<int>("SupportRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupportRequestId"));

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

                    b.HasIndex("CustomerId");

                    b.ToTable("SupportRequests");
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
