using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Hungary.Infrastructure.Migrations
{
    public partial class Invoice_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentInvoiceDataId",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentInvoiceDataId",
                table: "Invoices");
        }
    }
}
