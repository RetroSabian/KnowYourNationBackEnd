﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class FinalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimationsEntries",
                columns: table => new
                {
                    AnimationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationName = table.Column<string>(nullable: true),
                    AnimationFileLocation = table.Column<string>(nullable: true),
                    AnimationCoverImageLocation = table.Column<string>(nullable: true),
                    AnimationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationsEntries", x => x.AnimationsId);
                });

            migrationBuilder.CreateTable(
                name: "BooksEntries",
                columns: table => new
                {
                    BooksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookName = table.Column<string>(nullable: true),
                    BookFileLocation = table.Column<string>(nullable: true),
                    BookCoverImageLocation = table.Column<string>(nullable: true),
                    BookDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksEntries", x => x.BooksId);
                });

            migrationBuilder.CreateTable(
                name: "ComicsEntries",
                columns: table => new
                {
                    ComicsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicName = table.Column<string>(nullable: true),
                    ComicFileLocation = table.Column<string>(nullable: true),
                    ComicCoverImageLocation = table.Column<string>(nullable: true),
                    ComicDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicsEntries", x => x.ComicsId);
                });

            migrationBuilder.CreateTable(
                name: "MembershipsEntries",
                columns: table => new
                {
                    MembershipsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembershipType = table.Column<string>(nullable: true),
                    MembershipDuration = table.Column<DateTime>(nullable: false),
                    MembershipPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipsEntries", x => x.MembershipsId);
                });

            migrationBuilder.CreateTable(
                name: "NationsEntries",
                columns: table => new
                {
                    NationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NationName = table.Column<string>(nullable: true),
                    NationShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationsEntries", x => x.NationsId);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationsEntries",
                columns: table => new
                {
                    OrganisationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganisationName = table.Column<string>(nullable: true),
                    OrganisationDescription = table.Column<string>(nullable: true),
                    OrganisationURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationsEntries", x => x.OrganisationsId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsEntries",
                columns: table => new
                {
                    ProductsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    ProductCoverImageLocation = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductRating = table.Column<int>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductType = table.Column<string>(nullable: true),
                    ProductQuantityOnHand = table.Column<int>(nullable: false),
                    ProductSizeOption = table.Column<int>(nullable: true),
                    ProductColourOption = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsEntries", x => x.ProductsId);
                });

            migrationBuilder.CreateTable(
                name: "SpeedyCharactersEntries",
                columns: table => new
                {
                    SpeedyCharactersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterName = table.Column<string>(nullable: true),
                    CharacterDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedyCharactersEntries", x => x.SpeedyCharactersId);
                });

            migrationBuilder.CreateTable(
                name: "UsersEntries",
                columns: table => new
                {
                    UsersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserOrganisation = table.Column<string>(nullable: true),
                    MembershipExpiration = table.Column<DateTime>(nullable: false),
                    MembershipsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersEntries", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_UsersEntries_MembershipsEntries_MembershipsId",
                        column: x => x.MembershipsId,
                        principalTable: "MembershipsEntries",
                        principalColumn: "MembershipsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticlesEntries",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleName = table.Column<string>(nullable: true),
                    ArticleFileLocation = table.Column<string>(nullable: true),
                    ArticleCoverImageLocation = table.Column<string>(nullable: true),
                    ArticleDescription = table.Column<string>(nullable: true),
                    NationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesEntries", x => x.ArticlesId);
                    table.ForeignKey(
                        name: "FK_ArticlesEntries_NationsEntries_NationsId",
                        column: x => x.NationsId,
                        principalTable: "NationsEntries",
                        principalColumn: "NationsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventsEntries",
                columns: table => new
                {
                    EventsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventStreet = table.Column<string>(nullable: true),
                    EventSuburb = table.Column<string>(nullable: true),
                    EventCity = table.Column<string>(nullable: true),
                    EventPostalCode = table.Column<string>(nullable: true),
                    OrganisationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsEntries", x => x.EventsId);
                    table.ForeignKey(
                        name: "FK_EventsEntries_OrganisationsEntries_OrganisationsId",
                        column: x => x.OrganisationsId,
                        principalTable: "OrganisationsEntries",
                        principalColumn: "OrganisationsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimationsWatchedEntries",
                columns: table => new
                {
                    AnimationsWatchedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationsId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    AnimationWatchedStatus = table.Column<bool>(nullable: false),
                    AnimationBookmark = table.Column<bool>(nullable: false),
                    AnimationAllocated = table.Column<bool>(nullable: false),
                    AnimationRating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationsWatchedEntries", x => x.AnimationsWatchedId);
                    table.ForeignKey(
                        name: "FK_AnimationsWatchedEntries_AnimationsEntries_AnimationsId",
                        column: x => x.AnimationsId,
                        principalTable: "AnimationsEntries",
                        principalColumn: "AnimationsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationsWatchedEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksReadEntries",
                columns: table => new
                {
                    BooksReadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BooksId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    BookReadStatus = table.Column<bool>(nullable: false),
                    BookBookmark = table.Column<bool>(nullable: false),
                    BookRating = table.Column<int>(nullable: true),
                    BookAllocated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksReadEntries", x => x.BooksReadId);
                    table.ForeignKey(
                        name: "FK_BooksReadEntries_BooksEntries_BooksId",
                        column: x => x.BooksId,
                        principalTable: "BooksEntries",
                        principalColumn: "BooksId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksReadEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicsReadEntries",
                columns: table => new
                {
                    ComicsReadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicsId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    ComicReadStatus = table.Column<bool>(nullable: false),
                    ComicBookmark = table.Column<bool>(nullable: false),
                    ComicRating = table.Column<int>(nullable: true),
                    ComicAllocated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicsReadEntries", x => x.ComicsReadId);
                    table.ForeignKey(
                        name: "FK_ComicsReadEntries_ComicsEntries_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "ComicsEntries",
                        principalColumn: "ComicsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicsReadEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationsEntries",
                columns: table => new
                {
                    DonationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<string>(nullable: true),
                    DonatationAmount = table.Column<double>(nullable: false),
                    OrganizationUrl = table.Column<string>(nullable: true),
                    DonationDate = table.Column<DateTime>(nullable: false),
                    UsersId = table.Column<int>(nullable: true),
                    OrganisationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationsEntries", x => x.DonationsId);
                    table.ForeignKey(
                        name: "FK_DonationsEntries_OrganisationsEntries_OrganisationsId",
                        column: x => x.OrganisationsId,
                        principalTable: "OrganisationsEntries",
                        principalColumn: "OrganisationsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationsEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdersEntries",
                columns: table => new
                {
                    OrdersId = table.Column<int>(nullable: false)
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
                    UsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersEntries", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_OrdersEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticlesReadEntries",
                columns: table => new
                {
                    ArticlesReadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticlesId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    ArticleReadStatus = table.Column<bool>(nullable: false),
                    ArticleBookmark = table.Column<bool>(nullable: false),
                    ArticleAllocated = table.Column<bool>(nullable: false),
                    ArticleRating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesReadEntries", x => x.ArticlesReadId);
                    table.ForeignKey(
                        name: "FK_ArticlesReadEntries_ArticlesEntries_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "ArticlesEntries",
                        principalColumn: "ArticlesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticlesReadEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventsEntries",
                columns: table => new
                {
                    UserEventsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventsId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventsEntries", x => x.UserEventsId);
                    table.ForeignKey(
                        name: "FK_UserEventsEntries_EventsEntries_EventsId",
                        column: x => x.EventsId,
                        principalTable: "EventsEntries",
                        principalColumn: "EventsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEventsEntries_UsersEntries_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersEntries",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrdersEntries",
                columns: table => new
                {
                    ProductOrdersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrdersId = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrdersEntries", x => x.ProductOrdersId);
                    table.ForeignKey(
                        name: "FK_ProductOrdersEntries_OrdersEntries_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "OrdersEntries",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrdersEntries_ProductsEntries_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductsEntries",
                        principalColumn: "ProductsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationsWatchedEntries_AnimationsId",
                table: "AnimationsWatchedEntries",
                column: "AnimationsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationsWatchedEntries_UsersId",
                table: "AnimationsWatchedEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesEntries_NationsId",
                table: "ArticlesEntries",
                column: "NationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesReadEntries_ArticlesId",
                table: "ArticlesReadEntries",
                column: "ArticlesId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesReadEntries_UsersId",
                table: "ArticlesReadEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReadEntries_BooksId",
                table: "BooksReadEntries",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReadEntries_UsersId",
                table: "BooksReadEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicsReadEntries_ComicsId",
                table: "ComicsReadEntries",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicsReadEntries_UsersId",
                table: "ComicsReadEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationsEntries_OrganisationsId",
                table: "DonationsEntries",
                column: "OrganisationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationsEntries_UsersId",
                table: "DonationsEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsEntries_OrganisationsId",
                table: "EventsEntries",
                column: "OrganisationsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersEntries_UsersId",
                table: "OrdersEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrdersEntries_OrdersId",
                table: "ProductOrdersEntries",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrdersEntries_ProductsId",
                table: "ProductOrdersEntries",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventsEntries_EventsId",
                table: "UserEventsEntries",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventsEntries_UsersId",
                table: "UserEventsEntries",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersEntries_MembershipsId",
                table: "UsersEntries",
                column: "MembershipsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationsWatchedEntries");

            migrationBuilder.DropTable(
                name: "ArticlesReadEntries");

            migrationBuilder.DropTable(
                name: "BooksReadEntries");

            migrationBuilder.DropTable(
                name: "ComicsReadEntries");

            migrationBuilder.DropTable(
                name: "DonationsEntries");

            migrationBuilder.DropTable(
                name: "ProductOrdersEntries");

            migrationBuilder.DropTable(
                name: "SpeedyCharactersEntries");

            migrationBuilder.DropTable(
                name: "UserEventsEntries");

            migrationBuilder.DropTable(
                name: "AnimationsEntries");

            migrationBuilder.DropTable(
                name: "ArticlesEntries");

            migrationBuilder.DropTable(
                name: "BooksEntries");

            migrationBuilder.DropTable(
                name: "ComicsEntries");

            migrationBuilder.DropTable(
                name: "OrdersEntries");

            migrationBuilder.DropTable(
                name: "ProductsEntries");

            migrationBuilder.DropTable(
                name: "EventsEntries");

            migrationBuilder.DropTable(
                name: "NationsEntries");

            migrationBuilder.DropTable(
                name: "UsersEntries");

            migrationBuilder.DropTable(
                name: "OrganisationsEntries");

            migrationBuilder.DropTable(
                name: "MembershipsEntries");
        }
    }
}