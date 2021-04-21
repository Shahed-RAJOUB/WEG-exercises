using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.Data.Migrations
{
    public partial class userSubjectApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fotoTitle",
                table: "Members",
                newName: "FotoTitle");

            migrationBuilder.AddColumn<string>(
                name: "UserSubject",
                table: "Members",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserSubject",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "FotoTitle",
                table: "Members",
                newName: "fotoTitle");
        }
    }
}
