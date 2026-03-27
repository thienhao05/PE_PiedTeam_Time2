using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetPee.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Password", "Role", "UpdatedAt" },
                values: new object[] { new Guid("81051e28-d183-4704-9d90-36c09111f1fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@gmail.com", false, "PiedTeam", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81051e28-d183-4704-9d90-36c09111f1fd"));
        }
    }
}
