using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dkk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Volume24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange1H = table.Column<double>(type: "float", nullable: false),
                    PercentChange24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange7D = table.Column<double>(type: "float", nullable: false),
                    PercentChange30D = table.Column<double>(type: "float", nullable: false),
                    PercentChange60D = table.Column<double>(type: "float", nullable: false),
                    PercentChange90D = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    MarketCapDominance = table.Column<double>(type: "float", nullable: false),
                    FullyDilutedMarketCap = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dkk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eur",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Volume24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange1H = table.Column<double>(type: "float", nullable: false),
                    PercentChange24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange7D = table.Column<double>(type: "float", nullable: false),
                    PercentChange30D = table.Column<double>(type: "float", nullable: false),
                    PercentChange60D = table.Column<double>(type: "float", nullable: false),
                    PercentChange90D = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    MarketCapDominance = table.Column<double>(type: "float", nullable: false),
                    FullyDilutedMarketCap = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Volume24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange1H = table.Column<double>(type: "float", nullable: false),
                    PercentChange24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange7D = table.Column<double>(type: "float", nullable: false),
                    PercentChange30D = table.Column<double>(type: "float", nullable: false),
                    PercentChange60D = table.Column<double>(type: "float", nullable: false),
                    PercentChange90D = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    MarketCapDominance = table.Column<double>(type: "float", nullable: false),
                    FullyDilutedMarketCap = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Volume24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange1H = table.Column<double>(type: "float", nullable: false),
                    PercentChange24H = table.Column<double>(type: "float", nullable: false),
                    PercentChange7D = table.Column<double>(type: "float", nullable: false),
                    PercentChange30D = table.Column<double>(type: "float", nullable: false),
                    PercentChange60D = table.Column<double>(type: "float", nullable: false),
                    PercentChange90D = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    MarketCapDominance = table.Column<double>(type: "float", nullable: false),
                    FullyDilutedMarketCap = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsdId = table.Column<long>(type: "bigint", nullable: true),
                    DkkId = table.Column<long>(type: "bigint", nullable: true),
                    EurId = table.Column<long>(type: "bigint", nullable: true),
                    ZarId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote_Dkk_DkkId",
                        column: x => x.DkkId,
                        principalTable: "Dkk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Eur_EurId",
                        column: x => x.EurId,
                        principalTable: "Eur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Usd_UsdId",
                        column: x => x.UsdId,
                        principalTable: "Usd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Zar_ZarId",
                        column: x => x.ZarId,
                        principalTable: "Zar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoinMarketCapQuote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumMarketPairs = table.Column<long>(type: "bigint", nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MaxSupply = table.Column<long>(type: "bigint", nullable: true),
                    CirculatingSupply = table.Column<double>(type: "float", nullable: false),
                    TotalSupply = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<long>(type: "bigint", nullable: false),
                    CmcRank = table.Column<long>(type: "bigint", nullable: false),
                    IsFiat = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    QuoteId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinMarketCapQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinMarketCapQuote_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinMarketCapQuote_QuoteId",
                table: "CoinMarketCapQuote",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_DkkId",
                table: "Quote",
                column: "DkkId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_EurId",
                table: "Quote",
                column: "EurId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_UsdId",
                table: "Quote",
                column: "UsdId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ZarId",
                table: "Quote",
                column: "ZarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinMarketCapQuote");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Dkk");

            migrationBuilder.DropTable(
                name: "Eur");

            migrationBuilder.DropTable(
                name: "Usd");

            migrationBuilder.DropTable(
                name: "Zar");
        }
    }
}
