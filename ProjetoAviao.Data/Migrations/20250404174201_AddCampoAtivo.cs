using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAviao.Data.Migrations
{
    public partial class AddCampoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ativo",
                table: "Avioes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Avioes");
        }
    }
}
