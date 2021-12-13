using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProductRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubProduct",
                table: "InvoiceDetail",
                newName: "SubProductName");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "InvoiceDetail",
                newName: "ProductName");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceDetail");

            migrationBuilder.RenameColumn(
                name: "SubProductName",
                table: "InvoiceDetail",
                newName: "SubProduct");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "InvoiceDetail",
                newName: "Product");
        }
    }
}
