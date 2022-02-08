using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Customers.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUST_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    CUST_QUANTITY = table.Column<int>(nullable: false),
                    CUST_DATE_CREATE = table.Column<DateTime>(nullable: false),
                    CUST_DATE_UPDATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CUST_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
