using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class ekin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalars",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalars", x => x.MarkaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markalars");
        }
    }
}
