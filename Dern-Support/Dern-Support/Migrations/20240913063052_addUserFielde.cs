using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class addUserFielde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SupportRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "ApplicationUserId", "SubmittedDate" },
                values: new object[] { null, new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5524) });

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
                columns: new[] { "ApplicationUserId", "SubmittedDate" },
                values: new object[] { null, new DateTime(2024, 9, 13, 9, 30, 52, 27, DateTimeKind.Local).AddTicks(5432) });

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

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_ApplicationUserId",
                table: "SupportRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_AspNetUsers_ApplicationUserId",
                table: "SupportRequests",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_AspNetUsers_ApplicationUserId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportRequests_ApplicationUserId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

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
    }
}
