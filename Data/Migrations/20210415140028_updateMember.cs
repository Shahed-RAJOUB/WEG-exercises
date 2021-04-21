using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.Data.Migrations
{
    public partial class updateMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Members",
                newName: "fotoTitle");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Members",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Members",
                newName: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fotoTitle",
                table: "Members",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Members",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Members",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "TEXT",
                nullable: true);
        }
    }
}
