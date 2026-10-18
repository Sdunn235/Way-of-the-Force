using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeworld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Homeworld",
                table: "Creeds",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Homeworld",
                value: "Coruscant");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Homeworld",
                value: "Moraband");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 3,
                column: "Homeworld",
                value: "Yavin 4");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 4,
                column: "Homeworld",
                value: "Coruscant");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 5,
                column: "Homeworld",
                value: "Mandalore");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 6,
                column: "Homeworld",
                value: "Kashyyyk");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 7,
                column: "Homeworld",
                value: "Bastion");

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 8,
                column: "Homeworld",
                value: "Tython");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Homeworld",
                table: "Creeds");
        }
    }
}
