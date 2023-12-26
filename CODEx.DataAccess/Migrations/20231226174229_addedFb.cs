using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedFb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Facebook", "Instagram" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Facebook", "Instagram" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Facebook", "Instagram" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Coordinator",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Facebook", "Instagram" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Coordinator");
        }
    }
}
