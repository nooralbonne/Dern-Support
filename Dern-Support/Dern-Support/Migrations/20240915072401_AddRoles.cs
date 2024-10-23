using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6589), new DateTime(2024, 9, 16, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 15, 10, 24, 1, 55, DateTimeKind.Local).AddTicks(6181));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4266), new DateTime(2024, 9, 15, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 14, 17, 14, 39, 741, DateTimeKind.Local).AddTicks(3695));
        }
    }
}
