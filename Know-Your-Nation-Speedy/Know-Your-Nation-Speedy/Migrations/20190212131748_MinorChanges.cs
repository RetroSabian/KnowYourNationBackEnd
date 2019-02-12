using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowAnimations",
                table: "MembershipsEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowArticles",
                table: "MembershipsEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowBooks",
                table: "MembershipsEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowComics",
                table: "MembershipsEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MembershipsEntries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowAnimations",
                table: "MembershipsEntries");

            migrationBuilder.DropColumn(
                name: "AllowArticles",
                table: "MembershipsEntries");

            migrationBuilder.DropColumn(
                name: "AllowBooks",
                table: "MembershipsEntries");

            migrationBuilder.DropColumn(
                name: "AllowComics",
                table: "MembershipsEntries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MembershipsEntries");
        }
    }
}
