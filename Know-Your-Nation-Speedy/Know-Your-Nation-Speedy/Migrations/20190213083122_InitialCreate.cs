using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComicEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Duration = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AllowArticle = table.Column<bool>(nullable: false),
                    AllowAnimation = table.Column<bool>(nullable: false),
                    AllowBook = table.Column<bool>(nullable: false),
                    AllowComic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationEntries", x => x.Id);
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
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    QuantityOnHand = table.Column<int>(nullable: false),
                    SizeOption = table.Column<int>(nullable: true),
                    ColourOption = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntries", x => x.Id);
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
                    MembershipExpiration = table.Column<DateTime>(nullable: false),
                    MembershipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntries_MembershipEntries_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "MembershipEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleEntries_NationEntries_NationId",
                        column: x => x.NationId,
                        principalTable: "NationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    OrganisationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEntries_OrganisationEntries_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "OrganisationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonatationAmount = table.Column<double>(nullable: false),
                    DonationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    OrganisationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationEntries_OrganisationEntries_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "OrganisationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TrackingNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    WatchedStatus = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Allocated = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnimationEntries_AnimationEntries_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "AnimationEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimationEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReadStatus = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    Allocated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookEntries_BookEntries_BookId",
                        column: x => x.BookId,
                        principalTable: "BookEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComicEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReadStatus = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    Allocated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComicEntries_ComicEntries_ComicId",
                        column: x => x.ComicId,
                        principalTable: "ComicEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserArticleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReadStatus = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Allocated = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArticleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserArticleEntries_ArticleEntries_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ArticleEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserArticleEntries_UserEntries_UserId",
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
                name: "IX_ArticleEntries_NationId",
                table: "ArticleEntries",
                column: "NationId");

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
                name: "IX_ProductOrderEntries_OrderId",
                table: "ProductOrderEntries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntries_ProductId",
                table: "ProductOrderEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimationEntries_AnimationId",
                table: "UserAnimationEntries",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimationEntries_UserId",
                table: "UserAnimationEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticleEntries_ArticleId",
                table: "UserArticleEntries",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticleEntries_UserId",
                table: "UserArticleEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookEntries_BookId",
                table: "UserBookEntries",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookEntries_UserId",
                table: "UserBookEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicEntries_ComicId",
                table: "UserComicEntries",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicEntries_UserId",
                table: "UserComicEntries",
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
                name: "UserAnimationEntries");

            migrationBuilder.DropTable(
                name: "UserArticleEntries");

            migrationBuilder.DropTable(
                name: "UserBookEntries");

            migrationBuilder.DropTable(
                name: "UserComicEntries");

            migrationBuilder.DropTable(
                name: "UserEventEntries");

            migrationBuilder.DropTable(
                name: "OrderEntries");

            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.DropTable(
                name: "AnimationEntries");

            migrationBuilder.DropTable(
                name: "ArticleEntries");

            migrationBuilder.DropTable(
                name: "BookEntries");

            migrationBuilder.DropTable(
                name: "ComicEntries");

            migrationBuilder.DropTable(
                name: "EventEntries");

            migrationBuilder.DropTable(
                name: "UserEntries");

            migrationBuilder.DropTable(
                name: "NationEntries");

            migrationBuilder.DropTable(
                name: "OrganisationEntries");

            migrationBuilder.DropTable(
                name: "MembershipEntries");
        }
    }
}
