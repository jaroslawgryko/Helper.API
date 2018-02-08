using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Helper.API.Migrations
{
    public partial class ExtendedUserModelJednostkiModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstytucjaNazwa",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstytucjaRodzaj",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstytucjaSymbol",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OstatniaAktywnosc",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Utworzony",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Jednostki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataModyfikacji = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jednostki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jednostki_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jednostki_UserId",
                table: "Jednostki",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jednostki");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstytucjaNazwa",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstytucjaRodzaj",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstytucjaSymbol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OstatniaAktywnosc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Utworzony",
                table: "Users");
        }
    }
}
