using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AverageScore", "BestScore", "GamesPlayed", "GamesWon", "Name", "Password", "Username" },
                values: new object[] { 1, 0m, 0, 0, 0, "Thomas Mahr", "pass", "ThomasMahr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
