using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class addedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                table: "DonationEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DonationEntries_UserEntries_UserId",
                table: "DonationEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                table: "EventEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntries_UserEntries_UserId",
                table: "OrderEntries");

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
                name: "Rating",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "SizeOption",
                table: "ProductEntries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ProductEntries",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "QuantityOnHand",
                table: "ProductEntries",
                newName: "BaseProductId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductEntries",
                newName: "Colour");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OrderEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "EventEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DonationEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "DonationEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                table: "DonationEntries",
                column: "OrganisationId",
                principalTable: "OrganisationEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonationEntries_UserEntries_UserId",
                table: "DonationEntries",
                column: "UserId",
                principalTable: "UserEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                table: "EventEntries",
                column: "OrganisationId",
                principalTable: "OrganisationEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntries_UserEntries_UserId",
                table: "OrderEntries",
                column: "UserId",
                principalTable: "UserEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_BaseProductEntries_BaseProductId",
                table: "ProductEntries",
                column: "BaseProductId",
                principalTable: "BaseProductEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                table: "DonationEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DonationEntries_UserEntries_UserId",
                table: "DonationEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                table: "EventEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntries_UserEntries_UserId",
                table: "OrderEntries");

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
                newName: "QuantityOnHand");

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
                name: "Rating",
                table: "ProductEntries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeOption",
                table: "ProductEntries",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OrderEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "EventEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DonationEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "DonationEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                table: "DonationEntries",
                column: "OrganisationId",
                principalTable: "OrganisationEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonationEntries_UserEntries_UserId",
                table: "DonationEntries",
                column: "UserId",
                principalTable: "UserEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                table: "EventEntries",
                column: "OrganisationId",
                principalTable: "OrganisationEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntries_UserEntries_UserId",
                table: "OrderEntries",
                column: "UserId",
                principalTable: "UserEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
