using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AjustesServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Produtos",
                newName: "SOId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_SOId");

            migrationBuilder.CreateTable(
                name: "SO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SO", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SO_SOId",
                table: "Produtos",
                column: "SOId",
                principalTable: "SO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SO_SOId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "SO");

            migrationBuilder.RenameColumn(
                name: "SOId",
                table: "Produtos",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SOId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
