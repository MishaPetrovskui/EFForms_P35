using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFForms_P35.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsAndGroup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Curator",
                table: "Curator");

            migrationBuilder.RenameTable(
                name: "Curator",
                newName: "Curators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curators",
                table: "Curators",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Curators",
                table: "Curators");

            migrationBuilder.RenameTable(
                name: "Curators",
                newName: "Curator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curator",
                table: "Curator",
                column: "Id");
        }
    }
}
