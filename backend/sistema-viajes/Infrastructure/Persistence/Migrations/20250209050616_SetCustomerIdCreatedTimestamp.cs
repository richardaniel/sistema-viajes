using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetCustomerIdCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "CollaboratorId");

            migrationBuilder.AlterColumn<decimal>(
                name: "DistanceKm",
                table: "CollaboratorBranches",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldDefaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "DistanceKm",
                table: "CollaboratorBranches",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);
        }
    }
}
