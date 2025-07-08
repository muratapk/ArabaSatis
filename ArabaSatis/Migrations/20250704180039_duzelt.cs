using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class duzelt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IlanlarIlanId",
                table: "ArabaResim",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArabaResim_IlanlarIlanId",
                table: "ArabaResim",
                column: "IlanlarIlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArabaResim_Ilanlars_IlanlarIlanId",
                table: "ArabaResim",
                column: "IlanlarIlanId",
                principalTable: "Ilanlars",
                principalColumn: "IlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArabaResim_Ilanlars_IlanlarIlanId",
                table: "ArabaResim");

            migrationBuilder.DropIndex(
                name: "IX_ArabaResim_IlanlarIlanId",
                table: "ArabaResim");

            migrationBuilder.DropColumn(
                name: "IlanlarIlanId",
                table: "ArabaResim");
        }
    }
}
