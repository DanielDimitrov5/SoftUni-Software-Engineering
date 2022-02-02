using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Data.Migrations
{
    public partial class revertChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedProfiles");

            migrationBuilder.CreateTable(
                name: "UserProfileUserProfile",
                columns: table => new
                {
                    FollowedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileUserProfile", x => new { x.FollowedById, x.FollowsId });
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile_UserProfiles_FollowedById",
                        column: x => x.FollowedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile_UserProfiles_FollowsId",
                        column: x => x.FollowsId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileUserProfile_FollowsId",
                table: "UserProfileUserProfile",
                column: "FollowsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileUserProfile");

            migrationBuilder.CreateTable(
                name: "FollowedProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowedProfiles_UserProfiles_FollowedById",
                        column: x => x.FollowedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowedProfiles_FollowedById",
                table: "FollowedProfiles",
                column: "FollowedById");
        }
    }
}
