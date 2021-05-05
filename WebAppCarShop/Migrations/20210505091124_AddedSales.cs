using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCarShop.Migrations
{
    public partial class AddedSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TimeOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarInQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_CarInQuestionId",
                        column: x => x.CarInQuestionId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarInQuestionId",
                table: "Sales",
                column: "CarInQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
