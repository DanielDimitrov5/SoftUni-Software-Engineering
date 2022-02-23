﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia1.Migrations
{
    public partial class typoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surename",
                table: "UserProfiles",
                newName: "Surname");

            migrationBuilder.CreateTable(
                name: "FollowRequestViewModel",
                columns: table => new
                {
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowRequestViewModel", x => x.RequesterId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileViewModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostViewModel_ProfileViewModel_ProfileViewModelId",
                        column: x => x.ProfileViewModelId,
                        principalTable: "ProfileViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostViewModel_ProfileViewModelId",
                table: "PostViewModel",
                column: "ProfileViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowRequestViewModel");

            migrationBuilder.DropTable(
                name: "PostViewModel");

            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "UserProfiles",
                newName: "Surename");
        }
    }
}
