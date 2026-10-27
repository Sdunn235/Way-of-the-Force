using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayOfTheForce.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddHolocrons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holocrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WhenRecorded = table.Column<int>(type: "int", nullable: false),
                    CreedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holocrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holocrons_Creeds_CreedId",
                        column: x => x.CreedId,
                        principalTable: "Creeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holocrons_CreedId",
                table: "Holocrons",
                column: "CreedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holocrons");
        }
    }
}
