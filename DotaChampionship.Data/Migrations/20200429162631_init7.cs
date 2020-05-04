using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameType",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Games");
        }
    }
}
