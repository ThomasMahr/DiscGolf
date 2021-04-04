using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class GameFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GameFinished",
                table: "GamesPlayed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 1,
                column: "GameFinished",
                value: true);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 2,
                column: "GameFinished",
                value: true);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 3,
                column: "GameFinished",
                value: true);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 4,
                column: "GameFinished",
                value: true);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 5,
                column: "GameFinished",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameFinished",
                table: "GamesPlayed");
        }
    }
}
