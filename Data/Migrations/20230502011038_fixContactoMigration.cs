using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPEZANO.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixContactoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "asunto",
                table: "t_contacto",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "asunto",
                table: "t_contacto");
        }
    }
}
