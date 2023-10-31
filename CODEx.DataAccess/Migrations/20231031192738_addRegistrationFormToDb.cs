using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addRegistrationFormToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLeaderNanme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member4Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member4Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemStatment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationForm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationForm");
        }
    }
}
