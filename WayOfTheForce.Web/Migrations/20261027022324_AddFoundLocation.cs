using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddFoundLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoundLocation",
                table: "Holocrons",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundLocation",
                table: "Holocrons");
        }
    }
}
