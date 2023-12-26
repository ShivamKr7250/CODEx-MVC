using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 1,
                column: "Github",
                value: null);

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 2,
                column: "Github",
                value: null);

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 3,
                column: "Github",
                value: null);

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 4,
                column: "Github",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "Coordinator");
        }
    }
}
