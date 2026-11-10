using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHoloNetHandle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoloNetHandle",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoloNetHandle",
                table: "AspNetUsers");
        }
    }
}
