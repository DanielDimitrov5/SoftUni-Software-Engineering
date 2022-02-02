using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class UpdatePostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.Id);
                });
        }
    }
}
