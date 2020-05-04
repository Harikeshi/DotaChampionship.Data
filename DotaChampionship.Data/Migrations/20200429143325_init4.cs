using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaChampionship.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Tournament_TournamentId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGame_Games_GameId",
                table: "TeamGame");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGame_Teams_TeamId",
                table: "TeamGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Countries_CountryId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Year_YearId",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Year",
                table: "Year");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamGame",
                table: "TeamGame");

            migrationBuilder.RenameTable(
                name: "Year",
                newName: "Years");

            migrationBuilder.RenameTable(
                name: "Tournament",
                newName: "Tournaments");

            migrationBuilder.RenameTable(
                name: "TeamGame",
                newName: "TeamGames");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_YearId",
                table: "Tournaments",
                newName: "IX_Tournaments_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_CountryId",
                table: "Tournaments",
                newName: "IX_Tournaments_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGame_TeamId",
                table: "TeamGames",
                newName: "IX_TeamGames_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGame_GameId",
                table: "TeamGames",
                newName: "IX_TeamGames_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Years",
                table: "Years",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamGames",
                table: "TeamGames",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Commentators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentators_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(nullable: true),
                    Second = table.Column<string>(nullable: true),
                    Third = table.Column<string>(nullable: true),
                    FirstPrice = table.Column<decimal>(nullable: false),
                    SecondPrice = table.Column<decimal>(nullable: false),
                    ThirdPrice = table.Column<decimal>(nullable: false),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentators_GameId",
                table: "Commentators",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TournamentId",
                table: "Results",
                column: "TournamentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Tournaments_TournamentId",
                table: "Games",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGames_Games_GameId",
                table: "TeamGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGames_Teams_TeamId",
                table: "TeamGames",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Countries_CountryId",
                table: "Tournaments",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Years_YearId",
                table: "Tournaments",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Tournaments_TournamentId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGames_Games_GameId",
                table: "TeamGames");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGames_Teams_TeamId",
                table: "TeamGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Countries_CountryId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Years_YearId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Commentators");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Years",
                table: "Years");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamGames",
                table: "TeamGames");

            migrationBuilder.RenameTable(
                name: "Years",
                newName: "Year");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "Tournament");

            migrationBuilder.RenameTable(
                name: "TeamGames",
                newName: "TeamGame");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_YearId",
                table: "Tournament",
                newName: "IX_Tournament_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_CountryId",
                table: "Tournament",
                newName: "IX_Tournament_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGames_TeamId",
                table: "TeamGame",
                newName: "IX_TeamGame_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGames_GameId",
                table: "TeamGame",
                newName: "IX_TeamGame_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Year",
                table: "Year",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamGame",
                table: "TeamGame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Tournament_TournamentId",
                table: "Games",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGame_Games_GameId",
                table: "TeamGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGame_Teams_TeamId",
                table: "TeamGame",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Countries_CountryId",
                table: "Tournament",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Year_YearId",
                table: "Tournament",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
