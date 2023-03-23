using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SO_SOId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Produtos_ServidorId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Servidores");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SOId",
                table: "Servidores",
                newName: "IX_Servidores_SOId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servidores",
                table: "Servidores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_SO_SOId",
                table: "Servidores",
                column: "SOId",
                principalTable: "SO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Servidores_ServidorId",
                table: "Tag",
                column: "ServidorId",
                principalTable: "Servidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_SO_SOId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Servidores_ServidorId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servidores",
                table: "Servidores");

            migrationBuilder.RenameTable(
                name: "Servidores",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Servidores_SOId",
                table: "Produtos",
                newName: "IX_Produtos_SOId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SO_SOId",
                table: "Produtos",
                column: "SOId",
                principalTable: "SO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Produtos_ServidorId",
                table: "Tag",
                column: "ServidorId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
