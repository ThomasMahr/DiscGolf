using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class StartedPlayerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartedByPlayerID",
                table: "GamesPlayed",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 1,
                column: "StartedByPlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 2,
                column: "StartedByPlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 3,
                column: "StartedByPlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 4,
                column: "StartedByPlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 5,
                column: "StartedByPlayerID",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartedByPlayerID",
                table: "GamesPlayed");
        }
    }
}
