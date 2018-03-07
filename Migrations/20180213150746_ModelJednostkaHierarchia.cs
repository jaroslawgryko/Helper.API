using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Helper.API.Migrations
{
    public partial class ModelJednostkaHierarchia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Jednostki",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jednostki_ParentId",
                table: "Jednostki",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jednostki_Jednostki_ParentId",
                table: "Jednostki",
                column: "ParentId",
                principalTable: "Jednostki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jednostki_Jednostki_ParentId",
                table: "Jednostki");

            migrationBuilder.DropIndex(
                name: "IX_Jednostki_ParentId",
                table: "Jednostki");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Jednostki");
        }
    }
}
