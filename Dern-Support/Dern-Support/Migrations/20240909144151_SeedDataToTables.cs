using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "ItemId", "Category", "ItemName", "PricePerUnit", "QuantityInStock", "ReorderThreshold", "SupplierName" },
                values: new object[,]
                {
                    { 1, 1, "Screwdriver", 19.99m, 100, 10, "ToolSupplier" },
                    { 2, 0, "Resistor", 0.10m, 500, 50, "ElectronicsSupplier" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "UserId", "CreatedDate", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5202), "admin@example.com", "adminHash", "Admin", "admin" },
                    { 2, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5216), "tech@example.com", "techHash", "Technician", "tech" },
                    { 3, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5217), "cust1@example.com", "cust1Hash", "Customer", "cust1" },
                    { 4, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5219), "cust2@example.com", "cust2Hash", "Customer", "cust2" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CompanyName", "CreatedDate", "CustomerType", "Email", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Elm Street", "N/A", new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5396), "Individual", "alice.smith@example.com", "Alice Smith", "987-654-3210", 3 },
                    { 2, "456 Oak Avenue", "Business Corp", new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5398), "Business", "info@businesscorp.com", "Business Corp", "123-456-7890", 4 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "AvailabilityStatus", "Email", "ExperienceYears", "FullName", "PhoneNumber", "Specialization", "UserId" },
                values: new object[] { 1, "Available", "john.doe@example.com", 5, "John Doe", "123-456-7890", "Electrical", 2 });

            migrationBuilder.InsertData(
                table: "KnowledgeBases",
                columns: new[] { "ArticleId", "Author", "Category", "Content", "DatePublished", "TechnicianId", "Title" },
                values: new object[] { 1, "John Doe", "Hardware", "Step-by-step guide to fix AC issues.", new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5501), 1, "How to fix a broken AC" });

            migrationBuilder.InsertData(
                table: "SupportRequests",
                columns: new[] { "SupportRequestId", "CustomerId", "RequestDescription", "ResponseDate", "Status", "SubmittedDate", "UrgencyLevel" },
                values: new object[] { 1, 1, "AC not working", null, "Submitted", new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5430), "High" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Comment", "CustomerId", "Rating", "SubmittedDate", "SupportRequestId" },
                values: new object[] { 1, "Excellent service!", 1, 5, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5572), 1 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "ActualCompletionTime", "CreatedDate", "EstimatedCompletionTime", "JobStatus", "Priority", "ScheduledDate", "SupportRequestId", "TechnicianId" },
                values: new object[] { 1, null, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5467), 120, "Scheduled", "High", new DateTime(2024, 9, 10, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5443), 1, 1 });

            migrationBuilder.InsertData(
                table: "JobHistories",
                columns: new[] { "JobHistoryId", "JobId", "Status", "StatusChangeDate", "TechnicianNote" },
                values: new object[] { 1, 1, "Pending", new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5556), "Awaiting parts" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "JobId", "PaymentDate", "PaymentMethod", "PaymentStatus" },
                values: new object[] { 1, 150.00m, 1, new DateTime(2024, 9, 9, 17, 41, 51, 723, DateTimeKind.Local).AddTicks(5484), "CreditCard", "Pending" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
