using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class paket3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Yorumlars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ilanlar",
                columns: table => new
                {
                    IlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    AracDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometre = table.Column<int>(type: "int", nullable: false),
                    YakitId = table.Column<int>(type: "int", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    MarkalarMarkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilanlar", x => x.IlanId);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Markalars_MarkalarMarkaId",
                        column: x => x.MarkalarMarkaId,
                        principalTable: "Markalars",
                        principalColumn: "MarkaId");
                    table.ForeignKey(
                        name: "FK_Ilanlar_Yakits_YakitId",
                        column: x => x.YakitId,
                        principalTable: "Yakits",
                        principalColumn: "YakitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_MarkalarMarkaId",
                table: "Ilanlar",
                column: "MarkalarMarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_YakitId",
                table: "Ilanlar",
                column: "YakitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ilanlar");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Yorumlars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
