using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCarShop.Migrations
{
    public partial class ModSaleCarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Cars_CarInQuestionId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "CarInQuestionId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Cars_CarInQuestionId",
                table: "Sales",
                column: "CarInQuestionId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Cars_CarInQuestionId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "CarInQuestionId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Cars_CarInQuestionId",
                table: "Sales",
                column: "CarInQuestionId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
