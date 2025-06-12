using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class yakit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yakits",
                columns: table => new
                {
                    YakitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YakitAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yakits", x => x.YakitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yakits");
        }
    }
}
