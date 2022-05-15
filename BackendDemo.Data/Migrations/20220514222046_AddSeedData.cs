using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDemo.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Adress", "CreatedBy", "CreatedDate", "FirstName", "IsDeleted", "LastName", "ModifiedBy", "ModifyDate", "PhoneNumber", "profilePicture" },
                values: new object[] { 1, "Turkey", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "555555555555", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
