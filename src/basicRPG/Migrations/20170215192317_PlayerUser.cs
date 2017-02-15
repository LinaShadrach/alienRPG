using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace basicRPG.Migrations
{
    public partial class PlayerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AppUserId",
                table: "Players",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_AppUserId",
                table: "Players",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_AppUserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AppUserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Players");
        }
    }
}
