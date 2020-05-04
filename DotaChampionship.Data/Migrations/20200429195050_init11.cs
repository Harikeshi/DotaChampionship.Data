using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Score1",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Score2",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Score2",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Games");
        }
    }
}
