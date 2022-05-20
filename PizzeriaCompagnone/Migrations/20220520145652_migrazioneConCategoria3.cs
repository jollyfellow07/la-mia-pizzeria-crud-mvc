using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaCompagnone.Migrations
{
    public partial class migrazioneConCategoria3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorie_Categorie_CategoriaId",
                table: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Categorie_CategoriaId",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Categorie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_CategoriaId",
                table: "Categorie",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorie_Categorie_CategoriaId",
                table: "Categorie",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }
    }
}
