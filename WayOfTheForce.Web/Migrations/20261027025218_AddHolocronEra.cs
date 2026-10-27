using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHolocronEra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Era",
                table: "Holocrons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Era",
                table: "Holocrons");
        }
    }
}
