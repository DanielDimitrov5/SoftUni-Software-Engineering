using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class AddMoreFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "UserProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserProfileId",
                table: "Posts",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "UserProfiles");
        }
    }
}
