using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class addFollowedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FollowedProfile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowedProfile_UserProfiles_FollowedById",
                        column: x => x.FollowedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowedProfile_FollowedById",
                table: "FollowedProfile",
                column: "FollowedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedProfile");

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
    }
}
