using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturosaurus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ShortCompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NipNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BildingNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AddressEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cutomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortCustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NipNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DaysToAddToDatePayment = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BildingNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cutomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Cutomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Cutomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Cutomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    AddressEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Cutomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Cutomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Cutomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Cutomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerNipNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerStreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerBildingNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorrectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDetailsId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CorrectionId = table.Column<int>(type: "int", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_CompanyDetails_CompanyDetailsId",
                        column: x => x.CompanyDetailsId,
                        principalTable: "CompanyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Cutomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Cutomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Invoices_CorrectionId",
                        column: x => x.CorrectionId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatValue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 300, nullable: false),
                    GrossValue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CustomerId",
                table: "BankAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_CustomerId",
                table: "EmailAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_TaxTypeId",
                table: "InvoiceItems",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_UnitTypeId",
                table: "InvoiceItems",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyDetailsId",
                table: "Invoices",
                column: "CompanyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CorrectionId",
                table: "Invoices",
                column: "CorrectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DocumentTypeId",
                table: "Invoices",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentTypeId",
                table: "Invoices",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CustomerId",
                table: "Phones",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "Cutomers");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "PaymentTypes");
        }
    }
}
