using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecomm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookWritters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWritters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    BookWritterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCovers_BookWritters_BookWritterId",
                        column: x => x.BookWritterId,
                        principalTable: "BookWritters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    BookUrl = table.Column<string>(type: "text", nullable: true),
                    Trending = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ISBNNUMBER = table.Column<string>(type: "text", nullable: true),
                    BookCoverId = table.Column<int>(type: "integer", nullable: true),
                    BookWritterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookCovers_BookCoverId",
                        column: x => x.BookCoverId,
                        principalTable: "BookCovers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_BookWritters_BookWritterId",
                        column: x => x.BookWritterId,
                        principalTable: "BookWritters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCovers_BookWritterId",
                table: "BookCovers",
                column: "BookWritterId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCoverId",
                table: "Books",
                column: "BookCoverId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookWritterId",
                table: "Books",
                column: "BookWritterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookCovers");

            migrationBuilder.DropTable(
                name: "BookWritters");
        }
    }
}
