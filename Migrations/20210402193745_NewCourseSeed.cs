using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class NewCourseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 1,
                column: "PlayerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 2,
                column: "PlayerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 3,
                column: "PlayerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 4,
                columns: new[] { "PlayerID", "Score" },
                values: new object[] { 3, 62 });

            migrationBuilder.InsertData(
                table: "Holes",
                columns: new[] { "HoleID", "CourseID", "Distance", "Par", "SequenceNumber" },
                values: new object[,]
                {
                    { 10, 2, 285.0, 3, 1 },
                    { 27, 2, 269.0, 3, 18 },
                    { 26, 2, 417.0, 4, 17 },
                    { 25, 2, 226.0, 3, 16 },
                    { 24, 2, 246.0, 3, 15 },
                    { 22, 2, 266.0, 3, 13 },
                    { 21, 2, 141.0, 3, 12 },
                    { 23, 2, 203.0, 3, 14 },
                    { 19, 2, 164.0, 3, 10 },
                    { 18, 2, 256.0, 3, 9 },
                    { 17, 2, 420.0, 4, 8 },
                    { 16, 2, 213.0, 3, 7 },
                    { 15, 2, 262.0, 3, 6 },
                    { 14, 2, 203.0, 3, 5 },
                    { 13, 2, 154.0, 3, 4 },
                    { 12, 2, 266.0, 3, 3 },
                    { 11, 2, 246.0, 3, 2 },
                    { 20, 2, 141.0, 3, 11 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 1,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Admin", "DiscGolf", "Admin" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 2,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Thomas Mahr", "Password", "ThomasMahr" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 3,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Alyssa Ader", "Engineering", "AAder" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 4, "Aaron Morphew", "Cyber", "AMorphew" },
                    { 5, "Charile Shin", "CompSci", "CShin" }
                });

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 5,
                column: "PlayerID",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 1,
                column: "PlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 2,
                column: "PlayerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 3,
                column: "PlayerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 4,
                columns: new[] { "PlayerID", "Score" },
                values: new object[] { 2, 31 });

            migrationBuilder.UpdateData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 5,
                column: "PlayerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 1,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Thomas Mahr", "password", "ThomasMahr" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 2,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Alyssa Ader", "Engineering", "AAder" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 3,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Aaron Morphew", "CompSci", "AMorphew" });
        }
    }
}
