using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinaCent.Blaze.Migrations
{
    public partial class UpdateAddFcm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCore.CurrencyExchangeRates");

            migrationBuilder.DropTable(
                name: "BusinessCore.CurrencyUnits");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.CartItems");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.CategoryTranslation");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.ProductCategories");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.ProductImages");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.ProductMetas");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.ProductReviews");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.ProductTags");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.Categories");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.Products");

            migrationBuilder.DropTable(
                name: "BusinessCore.Shop.Tags");

            migrationBuilder.CreateTable(
                name: "FCM.FcmMessageLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawJsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCM.FcmMessageLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FCM.FcmTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCM.FcmTopic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FCM.FcmUserDeviceToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCM.FcmUserDeviceToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FCM.FcmUserDeviceToken_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FCM.FcmUserTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FcmTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCM.FcmUserTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FCM.FcmUserTopic_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FCM.FcmUserTopic_FCM.FcmTopic_FcmTopicId",
                        column: x => x.FcmTopicId,
                        principalTable: "FCM.FcmTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FCM.FcmUserDeviceToken_UserId",
                table: "FCM.FcmUserDeviceToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FCM.FcmUserTopic_FcmTopicId",
                table: "FCM.FcmUserTopic",
                column: "FcmTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_FCM.FcmUserTopic_UserId",
                table: "FCM.FcmUserTopic",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FCM.FcmMessageLog");

            migrationBuilder.DropTable(
                name: "FCM.FcmUserDeviceToken");

            migrationBuilder.DropTable(
                name: "FCM.FcmUserTopic");

            migrationBuilder.DropTable(
                name: "FCM.FcmTopic");

            migrationBuilder.CreateTable(
                name: "BusinessCore.CurrencyExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConvertedValue = table.Column<decimal>(type: "decimal(25,12)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISOCurrencySymbolFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISOCurrencySymbolTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.CurrencyExchangeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.CurrencyUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyDecimalDigits = table.Column<int>(type: "int", nullable: false),
                    CurrencyDecimalSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyGroupSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyNativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyNegativePattern = table.Column<int>(type: "int", nullable: false),
                    CurrencyPositivePattern = table.Column<int>(type: "int", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISOCurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.CurrencyUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.Categories_BusinessCore.Shop.Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BusinessCore.Shop.Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerVisibleContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(25,12)", nullable: false),
                    EndSellAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeatureImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(25,12)", nullable: false),
                    SellerVisibleContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartSellAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.CategoryTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.CategoryTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.CategoryTranslation_BusinessCore.Shop.Categories_CoreId",
                        column: x => x.CoreId,
                        principalTable: "BusinessCore.Shop.Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.CartItems_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductCategories_BusinessCore.Shop.Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BusinessCore.Shop.Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductCategories_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    IsFeature = table.Column<bool>(type: "bit", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductImages_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.ProductMetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.ProductMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductMetas_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.ProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductReviews_BusinessCore.Shop.ProductReviews_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BusinessCore.Shop.ProductReviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductReviews_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCore.Shop.ProductTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCore.Shop.ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductTags_BusinessCore.Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BusinessCore.Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCore.Shop.ProductTags_BusinessCore.Shop.Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "BusinessCore.Shop.Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.CartItems_ProductId",
                table: "BusinessCore.Shop.CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.Categories_ParentId",
                table: "BusinessCore.Shop.Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.CategoryTranslation_CoreId",
                table: "BusinessCore.Shop.CategoryTranslation",
                column: "CoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductCategories_CategoryId",
                table: "BusinessCore.Shop.ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductCategories_ProductId",
                table: "BusinessCore.Shop.ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductImages_ProductId",
                table: "BusinessCore.Shop.ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductMetas_ProductId",
                table: "BusinessCore.Shop.ProductMetas",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductReviews_ParentId",
                table: "BusinessCore.Shop.ProductReviews",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductReviews_ProductId",
                table: "BusinessCore.Shop.ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductTags_ProductId",
                table: "BusinessCore.Shop.ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCore.Shop.ProductTags_TagId",
                table: "BusinessCore.Shop.ProductTags",
                column: "TagId");
        }
    }
}
