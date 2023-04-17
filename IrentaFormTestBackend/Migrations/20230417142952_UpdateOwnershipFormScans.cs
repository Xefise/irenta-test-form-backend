using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOwnershipFormScans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoAgreement",
                table: "OwnershipFormModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoAgreement",
                table: "OwnershipFormModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
