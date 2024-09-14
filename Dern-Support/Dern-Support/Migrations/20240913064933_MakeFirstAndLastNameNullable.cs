using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class MakeFirstAndLastNameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4049), new DateTime(2024, 9, 14, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 49, 33, 354, DateTimeKind.Local).AddTicks(3349));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "JobHistories",
                keyColumn: "JobHistoryId",
                keyValue: 1,
                column: "StatusChangeDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 9, 14, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "KnowledgeBases",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "SupportRequests",
                keyColumn: "SupportRequestId",
                keyValue: 1,
                column: "SubmittedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5177));
        }
    }
}
