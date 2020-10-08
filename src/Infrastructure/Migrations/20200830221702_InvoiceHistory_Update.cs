using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Hungary.Infrastructure.Migrations
{
    public partial class InvoiceHistory_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceDataReferenceId",
                table: "InvoiceHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHistory_InvoiceDataReferenceId",
                table: "InvoiceHistory",
                column: "InvoiceDataReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHistory_InvoiceDataReference_InvoiceDataReferenceId",
                table: "InvoiceHistory",
                column: "InvoiceDataReferenceId",
                principalTable: "InvoiceDataReference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHistory_InvoiceDataReference_InvoiceDataReferenceId",
                table: "InvoiceHistory");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHistory_InvoiceDataReferenceId",
                table: "InvoiceHistory");

            migrationBuilder.DropColumn(
                name: "InvoiceDataReferenceId",
                table: "InvoiceHistory");
        }
    }
}
