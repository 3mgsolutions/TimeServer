using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeServer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class LogRequestCurrentTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestCurrentTimes");

            migrationBuilder.CreateTable(
                name: "LogRequestCurrentTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestTimeStampUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRequestCurrentTimes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRequestCurrentTimes");

            migrationBuilder.CreateTable(
                name: "RequestCurrentTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestTimeStampUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCurrentTimes", x => x.Id);
                });
        }
    }
}
