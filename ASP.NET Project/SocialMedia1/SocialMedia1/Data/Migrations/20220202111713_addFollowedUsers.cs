using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class addFollowedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfileId",
                table: "UserProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserProfileId",
                table: "UserProfiles",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_UserProfiles_UserProfileId",
                table: "UserProfiles",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_UserProfiles_UserProfileId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserProfileId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserProfiles");
        }
    }
}
