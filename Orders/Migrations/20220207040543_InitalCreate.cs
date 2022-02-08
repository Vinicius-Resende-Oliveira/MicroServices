using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDER_Customer",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUST_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    CUST_DATE_CREATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_Customer", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ORDER_TOTAL_PRICE = table.Column<decimal>(nullable: false),
                    ORDER_DISCOUNT = table.Column<decimal>(nullable: false),
                    ORDER_DATE_CREATE = table.Column<DateTime>(nullable: false),
                    ORDER_DATE_UPDATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_Order_ORDER_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ORDER_Customer",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_Product",
                columns: table => new
                {
                    PROD_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    PROD_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    PROD_QUANTITY = table.Column<int>(nullable: false),
                    PROD_PRICE = table.Column<decimal>(nullable: false),
                    PROD_DATE_CREATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_Product", x => x.PROD_ID);
                    table.ForeignKey(
                        name: "FK_ORDER_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_Product_OrderId",
                table: "ORDER_Product",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ORDER_Customer");
        }
    }
}
