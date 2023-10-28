using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSocialMediaUrlLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramPostUrl",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkdinUrl",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FacebookUrl", "InstagramPostUrl", "LinkdinUrl", "VideoUrl" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FacebookUrl", "InstagramPostUrl", "LinkdinUrl", "VideoUrl" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FacebookUrl", "InstagramPostUrl", "LinkdinUrl", "VideoUrl" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FacebookUrl", "InstagramPostUrl", "LinkdinUrl", "VideoUrl" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "InstagramPostUrl",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LinkdinUrl",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Event");
        }
    }
}
