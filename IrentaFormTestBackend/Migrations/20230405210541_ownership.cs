using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class ownership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnershipFormModels",
                columns: table => new
                {
                    Key = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityType = table.Column<string>(type: "TEXT", nullable: false),
                    Inn = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ScanInn = table.Column<string>(type: "TEXT", nullable: false),
                    Ogrnip = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ScanOgrnip = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScanEgrip = table.Column<string>(type: "TEXT", nullable: false),
                    ScanLeaseAgreement = table.Column<string>(type: "TEXT", nullable: false),
                    NoAgreement = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipFormModels", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipBankDetailsEnumerable",
                columns: table => new
                {
                    Key = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnershipFormModelKey = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Bic = table.Column<uint>(type: "INTEGER", nullable: false),
                    BankBranchName = table.Column<string>(type: "TEXT", nullable: false),
                    CheckingAccount = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CorrespondentAccount = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipBankDetailsEnumerable", x => x.Key);
                    table.ForeignKey(
                        name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelKey",
                        column: x => x.OwnershipFormModelKey,
                        principalTable: "OwnershipFormModels",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelKey",
                table: "OwnershipBankDetailsEnumerable",
                column: "OwnershipFormModelKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnershipBankDetailsEnumerable");

            migrationBuilder.DropTable(
                name: "OwnershipFormModels");
        }
    }
}
