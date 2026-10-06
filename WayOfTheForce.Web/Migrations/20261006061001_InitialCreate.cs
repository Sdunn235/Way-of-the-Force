using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Affinity = table.Column<int>(type: "int", nullable: false),
                    TotalHolocrons = table.Column<int>(type: "int", nullable: false),
                    IsFriendly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creeds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Creeds",
                columns: new[] { "Id", "Affinity", "Creed", "CreedName", "IsFriendly", "TotalHolocrons" },
                values: new object[,]
                {
                    { 1, 95, "Peacekeepers who serve the light side of the Force", "Jedi Order", true, 0 },
                    { 2, -95, "Power through passion and mastery of the dark side", "Sith Order", false, 0 },
                    { 3, 70, "Freedom and hope against Imperial tyranny", "Rebel Alliance", true, 0 },
                    { 4, -85, "Order and control through Imperial rule", "Galactic Empire", false, 0 },
                    { 5, -55, "Honor, loyalty, and strength through the warrior creed", "Mandalorian Clans", false, 0 },
                    { 6, 30, "Loyalty, courage, and defense of Kashyyyk", "Wookiee Clans", true, 0 },
                    { 7, -25, "The Force is a powerful tool, but always loyalty to the Emperor.", "Imperial Knights", false, 0 },
                    { 8, 5, "There is no light without dark. Through passion, we gain strength.", "Jeaii Order", true, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creeds");
        }
    }
}
