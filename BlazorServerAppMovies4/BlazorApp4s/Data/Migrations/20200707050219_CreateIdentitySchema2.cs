using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp4s.Data.Migrations
{
    public partial class CreateIdentitySchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f220c3ee-1a28-472e-a187-a51202e4b960", "0d83afaf-5bc1-4d73-8734-77e2e02538a2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f057809-6054-4061-ba7b-e95d6db71414", "a4fda796-c9b1-4d18-997d-01bdda4c02fb", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f057809-6054-4061-ba7b-e95d6db71414");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f220c3ee-1a28-472e-a187-a51202e4b960");
        }
    }
}
