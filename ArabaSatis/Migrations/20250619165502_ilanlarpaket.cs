using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class ilanlarpaket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilanlar_Markalars_MarkalarMarkaId",
                table: "Ilanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilanlar_Yakits_YakitId",
                table: "Ilanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ilanlar",
                table: "Ilanlar");

            migrationBuilder.RenameTable(
                name: "Ilanlar",
                newName: "Ilanlars");

            migrationBuilder.RenameIndex(
                name: "IX_Ilanlar_YakitId",
                table: "Ilanlars",
                newName: "IX_Ilanlars_YakitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ilanlar_MarkalarMarkaId",
                table: "Ilanlars",
                newName: "IX_Ilanlars_MarkalarMarkaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ilanlars",
                table: "Ilanlars",
                column: "IlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilanlars_Markalars_MarkalarMarkaId",
                table: "Ilanlars",
                column: "MarkalarMarkaId",
                principalTable: "Markalars",
                principalColumn: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilanlars_Yakits_YakitId",
                table: "Ilanlars",
                column: "YakitId",
                principalTable: "Yakits",
                principalColumn: "YakitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilanlars_Markalars_MarkalarMarkaId",
                table: "Ilanlars");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilanlars_Yakits_YakitId",
                table: "Ilanlars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ilanlars",
                table: "Ilanlars");

            migrationBuilder.RenameTable(
                name: "Ilanlars",
                newName: "Ilanlar");

            migrationBuilder.RenameIndex(
                name: "IX_Ilanlars_YakitId",
                table: "Ilanlar",
                newName: "IX_Ilanlar_YakitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ilanlars_MarkalarMarkaId",
                table: "Ilanlar",
                newName: "IX_Ilanlar_MarkalarMarkaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ilanlar",
                table: "Ilanlar",
                column: "IlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilanlar_Markalars_MarkalarMarkaId",
                table: "Ilanlar",
                column: "MarkalarMarkaId",
                principalTable: "Markalars",
                principalColumn: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilanlar_Yakits_YakitId",
                table: "Ilanlar",
                column: "YakitId",
                principalTable: "Yakits",
                principalColumn: "YakitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
