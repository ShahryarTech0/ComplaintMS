using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocationWithRelationshipCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "MerchantLocations",
                newName: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantLocations_MerchantId",
                table: "MerchantLocations",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantLocations_Merchants_MerchantId",
                table: "MerchantLocations",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchantLocations_Merchants_MerchantId",
                table: "MerchantLocations");

            migrationBuilder.DropIndex(
                name: "IX_MerchantLocations_MerchantId",
                table: "MerchantLocations");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "MerchantLocations",
                newName: "ParentID");
        }
    }
}
