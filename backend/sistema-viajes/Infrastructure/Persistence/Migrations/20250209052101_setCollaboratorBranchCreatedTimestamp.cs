using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setCollaboratorBranchCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorBranches_Customers_CustomerId",
                table: "CollaboratorBranches");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CollaboratorBranches",
                newName: "CollaboratorId");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorBranches_CustomerId_BranchId",
                table: "CollaboratorBranches",
                newName: "IX_CollaboratorBranches_CollaboratorId_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorBranches_Customers_CollaboratorId",
                table: "CollaboratorBranches",
                column: "CollaboratorId",
                principalTable: "Customers",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorBranches_Customers_CollaboratorId",
                table: "CollaboratorBranches");

            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "CollaboratorBranches",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorBranches_CollaboratorId_BranchId",
                table: "CollaboratorBranches",
                newName: "IX_CollaboratorBranches_CustomerId_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorBranches_Customers_CustomerId",
                table: "CollaboratorBranches",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
