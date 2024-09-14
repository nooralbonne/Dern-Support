using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1619), new DateTime(2024, 9, 14, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 30, 54, 441, DateTimeKind.Local).AddTicks(943));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1886), new DateTime(2024, 9, 14, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1862) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 10, 27, 57, 247, DateTimeKind.Local).AddTicks(1622));
        }
    }
}
