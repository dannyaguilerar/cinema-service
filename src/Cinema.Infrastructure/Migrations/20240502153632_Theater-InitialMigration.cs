using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TheaterInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "theater",
                schema: "cnm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theater", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "uq_theater_name",
                schema: "cnm",
                table: "theater",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theater",
                schema: "cnm");
        }
    }
}
