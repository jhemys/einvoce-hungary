using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Hungary.Infrastructure.Migrations
{
    public partial class InvoiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "Invoices",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceHistory_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHistory_InvoiceId",
                table: "InvoiceHistory",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceHistory");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Invoices");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
