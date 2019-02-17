using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Know_Your_Nation_Speedy.Migrations
{
    public partial class RemovedRepeatedEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimationEntries");

            migrationBuilder.DropTable(
                name: "UserArticleEntries");

            migrationBuilder.DropTable(
                name: "UserBookEntries");

            migrationBuilder.DropTable(
                name: "UserComicEntries");

            migrationBuilder.DropTable(
                name: "AnimationEntries");

            migrationBuilder.DropTable(
                name: "ArticleEntries");

            migrationBuilder.DropTable(
                name: "BookEntries");

            migrationBuilder.DropTable(
                name: "ComicEntries");

            migrationBuilder.DropTable(
                name: "NationEntries");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "OrderEntries");

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "ProductEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "MembershipEntries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "EventEntries",
                nullable: false,
                defaultValue: false);

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
                name: "UserContentEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReadStatus = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    Allocated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContentEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContentEntries_ContentEntries_ContentId",
                        column: x => x.ContentId,
                        principalTable: "ContentEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContentEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserContentEntries_ContentId",
                table: "UserContentEntries",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContentEntries_UserId",
                table: "UserContentEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContentEntries");

            migrationBuilder.DropTable(
                name: "ContentEntries");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "ProductEntries");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "MembershipEntries");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "EventEntries");

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "OrderEntries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allocated = table.Column<bool>(nullable: false),
                    AnimationId = table.Column<int>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    WatchedStatus = table.Column<bool>(nullable: false)
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
                    Allocated = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    ReadStatus = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
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
                    Allocated = table.Column<bool>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    ComicId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    ReadStatus = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
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
                name: "ArticleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverImageLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                name: "UserArticleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allocated = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Bookmark = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    ReadStatus = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleEntries_NationId",
                table: "ArticleEntries",
                column: "NationId");

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
        }
    }
}
