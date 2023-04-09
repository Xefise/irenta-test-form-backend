using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class filemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnershipBankDetailsEnumerable",
                table: "OwnershipBankDetailsEnumerable");

            migrationBuilder.DropColumn(
                name: "ScanEgrip",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanInn",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanLeaseAgreement",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanOgrnip",
                table: "OwnershipFormModels");

            migrationBuilder.RenameTable(
                name: "OwnershipBankDetailsEnumerable",
                newName: "OwnershipBankDetailsList");

            migrationBuilder.RenameIndex(
                name: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelId",
                table: "OwnershipBankDetailsList",
                newName: "IX_OwnershipBankDetailsList_OwnershipFormModelId");

            migrationBuilder.AddColumn<ulong>(
                name: "ScanEgripId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "ScanInnId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "ScanOgrnipId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnershipBankDetailsList",
                table: "OwnershipBankDetailsList",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FileModels",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipFormModels_ScanEgripId",
                table: "OwnershipFormModels",
                column: "ScanEgripId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipFormModels_ScanInnId",
                table: "OwnershipFormModels",
                column: "ScanInnId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipFormModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                column: "ScanLeaseAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipFormModels_ScanOgrnipId",
                table: "OwnershipFormModels",
                column: "ScanOgrnipId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipBankDetailsList_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsList",
                column: "OwnershipFormModelId",
                principalTable: "OwnershipFormModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanEgripId",
                table: "OwnershipFormModels",
                column: "ScanEgripId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanInnId",
                table: "OwnershipFormModels",
                column: "ScanInnId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                column: "ScanLeaseAgreementId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels",
                column: "ScanOgrnipId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipBankDetailsList_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsList");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanEgripId",
                table: "OwnershipFormModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanInnId",
                table: "OwnershipFormModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels");

            migrationBuilder.DropTable(
                name: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_OwnershipFormModels_ScanEgripId",
                table: "OwnershipFormModels");

            migrationBuilder.DropIndex(
                name: "IX_OwnershipFormModels_ScanInnId",
                table: "OwnershipFormModels");

            migrationBuilder.DropIndex(
                name: "IX_OwnershipFormModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels");

            migrationBuilder.DropIndex(
                name: "IX_OwnershipFormModels_ScanOgrnipId",
                table: "OwnershipFormModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnershipBankDetailsList",
                table: "OwnershipBankDetailsList");

            migrationBuilder.DropColumn(
                name: "ScanEgripId",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanInnId",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanLeaseAgreementId",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanOgrnipId",
                table: "OwnershipFormModels");

            migrationBuilder.RenameTable(
                name: "OwnershipBankDetailsList",
                newName: "OwnershipBankDetailsEnumerable");

            migrationBuilder.RenameIndex(
                name: "IX_OwnershipBankDetailsList_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable",
                newName: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelId");

            migrationBuilder.AddColumn<string>(
                name: "ScanEgrip",
                table: "OwnershipFormModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScanInn",
                table: "OwnershipFormModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScanLeaseAgreement",
                table: "OwnershipFormModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScanOgrnip",
                table: "OwnershipFormModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnershipBankDetailsEnumerable",
                table: "OwnershipBankDetailsEnumerable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable",
                column: "OwnershipFormModelId",
                principalTable: "OwnershipFormModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
