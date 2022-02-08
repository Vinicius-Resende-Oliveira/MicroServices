using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    PROD_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    PROD_DESCRIPTION = table.Column<string>(maxLength: 150, nullable: true),
                    PROD_NOTE = table.Column<string>(maxLength: 20000, nullable: true),
                    PROD_QUANTITY = table.Column<int>(nullable: false),
                    PROD_PRICE = table.Column<decimal>(nullable: false),
                    PROD_DATE_CREATE = table.Column<DateTime>(nullable: false),
                    PROD_DATE_UPDATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PROD_ID);
                });

            migrationBuilder.CreateTable(
                name: "Variation",
                columns: table => new
                {
                    VAR_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    VAR_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    VAR_QUANTITY = table.Column<int>(nullable: false),
                    VAR_PRICE = table.Column<decimal>(nullable: false),
                    VAR_DATE_CREATE = table.Column<DateTime>(nullable: false),
                    VAR_DATE_UPDATE = table.Column<DateTime>(nullable: false),
                    VariationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variation", x => x.VAR_ID);
                    table.ForeignKey(
                        name: "FK_Variation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "PROD_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variation_Variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "Variation",
                        principalColumn: "VAR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variation_ProductId",
                table: "Variation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variation_VariationId",
                table: "Variation",
                column: "VariationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variation");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
