using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCoordinatorToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinator", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coordinator",
                columns: new[] { "Id", "Batch", "Description", "Designation", "ImageUrl", "LinkedIn", "Name" },
                values: new object[,]
                {
                    { 1, "2021-2025", "This was a Technical Event", "President", null, null, "Da-Vinci Code 3.0" },
                    { 2, "2021-2025", "This was a Technical Event", "Vice-President", null, null, "X-QuizIT 3.0" },
                    { 3, "2021-2025", "This was a Technical Event", "Secretary", null, null, "Edge Map " },
                    { 4, "2021-2025", "This was a Technical Event", "Vice-Secretary", null, null, "TechNode" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinator");
        }
    }
}
