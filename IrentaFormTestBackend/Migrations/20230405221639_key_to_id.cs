using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class key_to_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelKey",
                table: "OwnershipBankDetailsEnumerable");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "OwnershipFormModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnershipFormModelKey",
                table: "OwnershipBankDetailsEnumerable",
                newName: "OwnershipFormModelId");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "OwnershipBankDetailsEnumerable",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelKey",
                table: "OwnershipBankDetailsEnumerable",
                newName: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable",
                column: "OwnershipFormModelId",
                principalTable: "OwnershipFormModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OwnershipFormModels",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable",
                newName: "OwnershipFormModelKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OwnershipBankDetailsEnumerable",
                newName: "Key");

            migrationBuilder.RenameIndex(
                name: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelId",
                table: "OwnershipBankDetailsEnumerable",
                newName: "IX_OwnershipBankDetailsEnumerable_OwnershipFormModelKey");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipBankDetailsEnumerable_OwnershipFormModels_OwnershipFormModelKey",
                table: "OwnershipBankDetailsEnumerable",
                column: "OwnershipFormModelKey",
                principalTable: "OwnershipFormModels",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
