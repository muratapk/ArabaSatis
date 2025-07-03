using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class paket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArabaResim",
                columns: table => new
                {
                    ArabaResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilanId = table.Column<int>(type: "int", nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaResim", x => x.ArabaResimId);
                });

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

            migrationBuilder.CreateTable(
                name: "Yorumlars",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilanId = table.Column<int>(type: "int", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlars", x => x.YorumId);
                });

            migrationBuilder.CreateTable(
                name: "SeriModels",
                columns: table => new
                {
                    SeriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    MarkalarsMarkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriModels", x => x.SeriId);
                    table.ForeignKey(
                        name: "FK_SeriModels_Markalars_MarkalarsMarkaId",
                        column: x => x.MarkalarsMarkaId,
                        principalTable: "Markalars",
                        principalColumn: "MarkaId");
                });

            migrationBuilder.CreateTable(
                name: "Ilanlars",
                columns: table => new
                {
                    IlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    AracDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometre = table.Column<int>(type: "int", nullable: true),
                    YakitId = table.Column<int>(type: "int", nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    MarkalarMarkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilanlars", x => x.IlanId);
                    table.ForeignKey(
                        name: "FK_Ilanlars_Markalars_MarkalarMarkaId",
                        column: x => x.MarkalarMarkaId,
                        principalTable: "Markalars",
                        principalColumn: "MarkaId");
                    table.ForeignKey(
                        name: "FK_Ilanlars_Yakits_YakitId",
                        column: x => x.YakitId,
                        principalTable: "Yakits",
                        principalColumn: "YakitId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlars_MarkalarMarkaId",
                table: "Ilanlars",
                column: "MarkalarMarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlars_YakitId",
                table: "Ilanlars",
                column: "YakitId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriModels_MarkalarsMarkaId",
                table: "SeriModels",
                column: "MarkalarsMarkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArabaResim");

            migrationBuilder.DropTable(
                name: "Ilanlars");

            migrationBuilder.DropTable(
                name: "SeriModels");

            migrationBuilder.DropTable(
                name: "Yorumlars");

            migrationBuilder.DropTable(
                name: "Yakits");

            migrationBuilder.DropTable(
                name: "Markalars");
        }
    }
}
