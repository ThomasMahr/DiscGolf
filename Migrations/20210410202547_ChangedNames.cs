using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscGolf.Migrations
{
    public partial class ChangedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 2,
                columns: new[] { "Name", "Username" },
                values: new object[] { "Ichabod Fletchman", "IFletchman" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 3,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Jimmy Craig", "Hockey", "JCraig" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 4,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Kerri Strug", "Vault", "KStrug" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 5,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Jesse Owens", "Track", "JOwens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 2,
                columns: new[] { "Name", "Username" },
                values: new object[] { "Thomas Mahr", "ThomasMahr" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 3,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Alyssa Ader", "Engineering", "AAder" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 4,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Aaron Morphew", "Cyber", "AMorphew" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerID",
                keyValue: 5,
                columns: new[] { "Name", "Password", "Username" },
                values: new object[] { "Charile Shin", "CompSci", "CShin" });
        }
    }
}
