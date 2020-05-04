using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Score2",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Score",
                table: "TeamGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "TeamGames");

            migrationBuilder.AddColumn<string>(
                name: "Score1",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Score2",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
