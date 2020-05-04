using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tournaments_TournamentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_TournamentId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_ResultId",
                table: "Tournaments",
                column: "ResultId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Results_ResultId",
                table: "Tournaments",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Results_ResultId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_ResultId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Tournaments");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Results_TournamentId",
                table: "Results",
                column: "TournamentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tournaments_TournamentId",
                table: "Results",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
