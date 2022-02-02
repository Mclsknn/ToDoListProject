using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "UserBirthDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "UserGender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ToDos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "Users");
            migrationBuilder.DropColumn(
                name: "UserBirthDate",
                table: "Users");
            migrationBuilder.DropColumn(
                name: "UserGender",
                table: "Users");
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ToDos");
        }
    }
}
