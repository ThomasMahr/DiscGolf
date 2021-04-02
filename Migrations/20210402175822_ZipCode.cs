using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class ZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "ZipCode",
                value: 20708);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "ZipCode" },
                values: new object[] { 2, "Turkey Hill Park", 20646 });

            migrationBuilder.UpdateData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 6,
                column: "Par",
                value: 4);

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Name", "Password", "Username" },
                values: new object[] { 3, "Aaron Morphew", "CompSci", "AMorphew" });

            migrationBuilder.InsertData(
                table: "GamesPlayed",
                columns: new[] { "GamePlayedID", "CourseID", "PlayerID", "Score" },
                values: new object[] { 4, 2, 2, 31 });

            migrationBuilder.InsertData(
                table: "GamesPlayed",
                columns: new[] { "GamePlayedID", "CourseID", "PlayerID", "Score" },
                values: new object[] { 5, 1, 3, 26 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "Holes",
                keyColumn: "HoleID",
                keyValue: 6,
                column: "Par",
                value: 6);
        }
    }
}
