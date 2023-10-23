using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addGlimpse1ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Glimpse1",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                column: "Glimpse1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                column: "Glimpse1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                column: "Glimpse1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4,
                column: "Glimpse1",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Glimpse1",
                table: "Event");
        }
    }
}
