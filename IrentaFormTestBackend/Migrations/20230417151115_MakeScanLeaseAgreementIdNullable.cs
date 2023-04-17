using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class MakeScanLeaseAgreementIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels");

            migrationBuilder.AlterColumn<ulong>(
                name: "ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                column: "ScanLeaseAgreementId",
                principalTable: "FileModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels");

            migrationBuilder.AlterColumn<ulong>(
                name: "ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanLeaseAgreementId",
                table: "OwnershipFormModels",
                column: "ScanLeaseAgreementId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
