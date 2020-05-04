using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_PlayerId",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PlayerId",
                table: "Roles",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_PlayerId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PlayerId",
                table: "Roles",
                column: "PlayerId",
                unique: true);
        }
    }
}
