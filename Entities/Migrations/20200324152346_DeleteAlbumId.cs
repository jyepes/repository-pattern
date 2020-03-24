using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class DeleteAlbumId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albumes_Artistas_ArtistaId",
                table: "Albumes");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Artistas");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistaId",
                table: "Albumes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albumes_Artistas_ArtistaId",
                table: "Albumes",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albumes_Artistas_ArtistaId",
                table: "Albumes");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Artistas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistaId",
                table: "Albumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Albumes_Artistas_ArtistaId",
                table: "Albumes",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
