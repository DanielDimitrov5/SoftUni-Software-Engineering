using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class addFollowedUserClassDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowedProfile_UserProfiles_FollowedById",
                table: "FollowedProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowedProfile",
                table: "FollowedProfile");

            migrationBuilder.RenameTable(
                name: "FollowedProfile",
                newName: "FollowedProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_FollowedProfile_FollowedById",
                table: "FollowedProfiles",
                newName: "IX_FollowedProfiles_FollowedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowedProfiles",
                table: "FollowedProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedProfiles_UserProfiles_FollowedById",
                table: "FollowedProfiles",
                column: "FollowedById",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowedProfiles_UserProfiles_FollowedById",
                table: "FollowedProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowedProfiles",
                table: "FollowedProfiles");

            migrationBuilder.RenameTable(
                name: "FollowedProfiles",
                newName: "FollowedProfile");

            migrationBuilder.RenameIndex(
                name: "IX_FollowedProfiles_FollowedById",
                table: "FollowedProfile",
                newName: "IX_FollowedProfile_FollowedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowedProfile",
                table: "FollowedProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedProfile_UserProfiles_FollowedById",
                table: "FollowedProfile",
                column: "FollowedById",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
