using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class VariationsToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColourOption",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "CoverImageLocation",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "QuantityOnHand",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductEntries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ProductEntries",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "SizeOption",
                table: "ProductEntries",
                newName: "BaseProductId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductEntries",
                newName: "Colour");

            migrationBuilder.CreateTable(
                name: "BaseProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsAlive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProductEntries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_BaseProductId",
                table: "ProductEntries",
                column: "BaseProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_BaseProductEntries_BaseProductId",
                table: "ProductEntries",
                column: "BaseProductId",
                principalTable: "BaseProductEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntries_BaseProductEntries_BaseProductId",
                table: "ProductEntries");

            migrationBuilder.DropTable(
                name: "BaseProductEntries");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntries_BaseProductId",
                table: "ProductEntries");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductEntries",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Colour",
                table: "ProductEntries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BaseProductId",
                table: "ProductEntries",
                newName: "SizeOption");

            migrationBuilder.AddColumn<int>(
                name: "ColourOption",
                table: "ProductEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageLocation",
                table: "ProductEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductEntries",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "ProductEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductEntries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOnHand",
                table: "ProductEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ProductEntries",
                nullable: true);
        }
    }
}
