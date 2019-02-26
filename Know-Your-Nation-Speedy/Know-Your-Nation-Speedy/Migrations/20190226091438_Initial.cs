using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ContentEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    ImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Association = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AllowArticle = table.Column<bool>(nullable: false),
                    AllowAnimation = table.Column<bool>(nullable: false),
                    AllowBook = table.Column<bool>(nullable: false),
                    AllowComic = table.Column<bool>(nullable: false),
                    IsAlive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeedyCharacterEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedyCharacterEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    BaseProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntries_BaseProductEntries_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "BaseProductEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserOrganisation = table.Column<string>(nullable: true),
                    MembershipId = table.Column<int>(nullable: false),
                    MembershipExpiration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntries_MembershipEntries_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "MembershipEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    IsAlive = table.Column<bool>(nullable: false),
                    OrganisationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "OrganisationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonatationAmount = table.Column<double>(nullable: false),
                    DonationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OrganisationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "OrganisationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOrdered = table.Column<DateTime>(nullable: false),
                    DateExpected = table.Column<DateTime>(nullable: false),
                    DeliveryStreet = table.Column<string>(nullable: true),
                    DeliverySuburb = table.Column<string>(nullable: true),
                    DeliveryCity = table.Column<string>(nullable: true),
                    DeliveryCountry = table.Column<string>(nullable: true),
                    DeliveryPostalCode = table.Column<string>(nullable: true),
                    IsBusiness = table.Column<bool>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookmarkEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookmarkEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookmarkEntries_ContentEntries_ContentId",
                        column: x => x.ContentId,
                        principalTable: "ContentEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookmarkEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRatingEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatingEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatingEntries_ContentEntries_ContentId",
                        column: x => x.ContentId,
                        principalTable: "ContentEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatingEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEventEntries_EventEntries_EventId",
                        column: x => x.EventId,
                        principalTable: "EventEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEventEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrderEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrderEntries_OrderEntries_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrderEntries_ProductEntries_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationEntries_OrganisationId",
                table: "DonationEntries",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationEntries_UserId",
                table: "DonationEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntries_OrganisationId",
                table: "EventEntries",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntries_UserId",
                table: "OrderEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_BaseProductId",
                table: "ProductEntries",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntries_OrderId",
                table: "ProductOrderEntries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntries_ProductId",
                table: "ProductOrderEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookmarkEntries_ContentId",
                table: "UserBookmarkEntries",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookmarkEntries_UserId",
                table: "UserBookmarkEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntries_MembershipId",
                table: "UserEntries",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventEntries_EventId",
                table: "UserEventEntries",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventEntries_UserId",
                table: "UserEventEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingEntries_ContentId",
                table: "UserRatingEntries",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingEntries_UserId",
                table: "UserRatingEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationEntries");

            migrationBuilder.DropTable(
                name: "ProductOrderEntries");

            migrationBuilder.DropTable(
                name: "SpeedyCharacterEntries");

            migrationBuilder.DropTable(
                name: "UserBookmarkEntries");

            migrationBuilder.DropTable(
                name: "UserEventEntries");

            migrationBuilder.DropTable(
                name: "UserRatingEntries");

            migrationBuilder.DropTable(
                name: "OrderEntries");

            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.DropTable(
                name: "EventEntries");

            migrationBuilder.DropTable(
                name: "ContentEntries");

            migrationBuilder.DropTable(
                name: "UserEntries");

            migrationBuilder.DropTable(
                name: "BaseProductEntries");

            migrationBuilder.DropTable(
                name: "OrganisationEntries");

            migrationBuilder.DropTable(
                name: "MembershipEntries");
        }
    }
}
