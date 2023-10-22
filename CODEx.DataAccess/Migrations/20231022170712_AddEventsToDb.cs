using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalParticipant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Date", "Description", "Name", "PosterUrl", "TotalParticipant" },
                values: new object[,]
                {
                    { 1, new DateOnly(1, 1, 1), "This was a Technical Event", "Da-Vinci Code 3.0", null, 70 },
                    { 2, new DateOnly(1, 1, 1), "This was a Technical Event", "X-QuizIT 3.0", null, 90 },
                    { 3, new DateOnly(1, 1, 1), "This was a Technical Event", "Edge Map ", null, 60 },
                    { 4, new DateOnly(1, 1, 1), "This was a Technical Event", "TechNode", null, 120 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
