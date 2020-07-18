using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Hungary.Infrastructure.Migrations
{
    public partial class Invoice_GuidColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Invoices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Invoices");
        }
    }
}
