using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class AddedIntDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "MembershipEntries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "MembershipEntries");
        }
    }
}
