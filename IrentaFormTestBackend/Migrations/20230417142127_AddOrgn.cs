using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddOrgn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels");

            migrationBuilder.AlterColumn<ulong>(
                name: "ScanOgrnipId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<ulong>(
                name: "Ogrnip",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<ulong>(
                name: "Ogrn",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<ulong>(
                name: "ScanOgrnId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipFormModels_ScanOgrnId",
                table: "OwnershipFormModels",
                column: "ScanOgrnId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnId",
                table: "OwnershipFormModels",
                column: "ScanOgrnId",
                principalTable: "FileModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels",
                column: "ScanOgrnipId",
                principalTable: "FileModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnId",
                table: "OwnershipFormModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels");

            migrationBuilder.DropIndex(
                name: "IX_OwnershipFormModels_ScanOgrnId",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "Ogrn",
                table: "OwnershipFormModels");

            migrationBuilder.DropColumn(
                name: "ScanOgrnId",
                table: "OwnershipFormModels");

            migrationBuilder.AlterColumn<ulong>(
                name: "ScanOgrnipId",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Ogrnip",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipFormModels_FileModels_ScanOgrnipId",
                table: "OwnershipFormModels",
                column: "ScanOgrnipId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
