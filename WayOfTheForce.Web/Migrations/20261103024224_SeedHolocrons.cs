using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedHolocrons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreedName",
                value: "Je'daii Order");

            migrationBuilder.InsertData(
                table: "Holocrons",
                columns: new[] { "Id", "Author", "CreedId", "Era", "FoundLocation", "Title", "WhenRecorded" },
                values: new object[,]
                {
                    { 1, "Tedryn", 1, 0, "Dantooine", "Tedryn Holocron", 4000 },
                    { 2, "Jocasta Nu", 1, 0, "Bogano Vault, Bogano", "Eno Cordova's Holocron", 14 },
                    { 3, "King Adas", 2, 0, "Korriban", "Holocron of King Adas", 27700 },
                    { 4, "Unknown Sith", 2, 0, "Malachor Sith Temple", "Sith Holocron of Malachor", 2 },
                    { 5, "Depa Billaba", 3, 0, "The Ghost", "Kanan Jarrus's Holocron", 19 },
                    { 6, "Unknown Jedi", 4, 1, "Dantooine", "Codex of Tython", 1 },
                    { 7, "Eshkar Niin", 7, 1, null, "Eshkar Niin's Holocron", 137 },
                    { 8, "Master Rajivari", 8, 0, "Tython", "Rajivari's Holocron", 25783 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Holocrons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Creeds",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreedName",
                value: "Jeaii Order");
        }
    }
}
