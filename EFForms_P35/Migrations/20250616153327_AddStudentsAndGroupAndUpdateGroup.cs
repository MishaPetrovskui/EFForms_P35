using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFForms_P35.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsAndGroupAndUpdateGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuratorId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CuratorId",
                table: "Groups",
                column: "CuratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Curators_CuratorId",
                table: "Groups",
                column: "CuratorId",
                principalTable: "Curators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Curators_CuratorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CuratorId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CuratorId",
                table: "Groups");
        }
    }
}
