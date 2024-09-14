using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class adminpermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9316), new DateTime(2024, 9, 14, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 2, 3, 49, 459, DateTimeKind.Local).AddTicks(8556));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(314), new DateTime(2024, 9, 11, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 229, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 228, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 228, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 13, 10, 49, 228, DateTimeKind.Local).AddTicks(9719));
        }
    }
}
