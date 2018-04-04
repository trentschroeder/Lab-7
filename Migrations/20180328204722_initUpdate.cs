using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fisher.Bookstore.Api.Migrations
{
    public partial class initUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Authorid",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authorid",
                table: "Books",
                column: "Authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Authorid",
                table: "Books",
                column: "Authorid",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Authorid",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Authorid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Authorid",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titles",
                table: "Authors",
                nullable: true);
        }
    }
}
