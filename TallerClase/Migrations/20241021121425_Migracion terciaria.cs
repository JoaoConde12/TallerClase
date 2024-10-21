using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerClase.Migrations
{
    /// <inheritdoc />
    public partial class Migracionterciaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Estadio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Estadio");
        }
    }
}
