using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class DatabaseRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursePar",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HolePar",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NumberOfHoles",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "GamesPlayed",
                columns: table => new
                {
                    GamePlayedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesPlayed", x => x.GamePlayedID);
                    table.ForeignKey(
                        name: "FK_GamesPlayed_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesPlayed_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    HoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.HoleID);
                    table.ForeignKey(
                        name: "FK_Holes_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GamesPlayed",
                columns: new[] { "GamePlayedID", "CourseID", "PlayerID", "Score" },
                values: new object[,]
                {
                    { 1, 1, 1, 26 },
                    { 2, 1, 1, 31 }
                });

            migrationBuilder.InsertData(
                table: "Holes",
                columns: new[] { "HoleID", "CourseID", "Distance", "Par", "SequenceNumber" },
                values: new object[,]
                {
                    { 1, 1, 317.01999999999998, 3, 1 },
                    { 2, 1, 305.48000000000002, 3, 2 },
                    { 3, 1, 297.37, 3, 3 },
                    { 4, 1, 188.97, 3, 4 },
                    { 5, 1, 253.03999999999999, 2, 5 },
                    { 6, 1, 360.47000000000003, 6, 6 },
                    { 7, 1, 172.59, 3, 7 },
                    { 8, 1, 348.94, 4, 8 },
                    { 9, 1, 186.06, 3, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 1,
                column: "Password",
                value: "password");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Name", "Password", "Username" },
                values: new object[] { 2, "Alyssa Ader", "Engineering", "AAder" });

            migrationBuilder.InsertData(
                table: "GamesPlayed",
                columns: new[] { "GamePlayedID", "CourseID", "PlayerID", "Score" },
                values: new object[] { 3, 1, 2, 29 });

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlayed_CourseID",
                table: "GamesPlayed",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlayed_PlayerID",
                table: "GamesPlayed",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Holes_CourseID",
                table: "Holes",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesPlayed");

            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "CoursePar",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HolePar",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfHoles",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "CoursePar", "HolePar", "NumberOfHoles" },
                values: new object[] { 28, "3-3-3-3-2-4-3-4-3", 9 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 1,
                column: "Password",
                value: "pass");
        }
    }
}
