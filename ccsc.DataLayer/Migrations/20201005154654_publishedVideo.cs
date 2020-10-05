using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class publishedVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublishedVideo_Products_ProductId",
                table: "PublishedVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_PublishedVideo_Videos_VideoId",
                table: "PublishedVideo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishedVideo",
                table: "PublishedVideo");

            migrationBuilder.RenameTable(
                name: "PublishedVideo",
                newName: "PublishedVideos");

            migrationBuilder.RenameIndex(
                name: "IX_PublishedVideo_VideoId",
                table: "PublishedVideos",
                newName: "IX_PublishedVideos_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_PublishedVideo_ProductId",
                table: "PublishedVideos",
                newName: "IX_PublishedVideos_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "PublishedVideos",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishedVideos",
                table: "PublishedVideos",
                column: "PublishedVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedVideos_Products_ProductId",
                table: "PublishedVideos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedVideos_Videos_VideoId",
                table: "PublishedVideos",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublishedVideos_Products_ProductId",
                table: "PublishedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_PublishedVideos_Videos_VideoId",
                table: "PublishedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishedVideos",
                table: "PublishedVideos");

            migrationBuilder.RenameTable(
                name: "PublishedVideos",
                newName: "PublishedVideo");

            migrationBuilder.RenameIndex(
                name: "IX_PublishedVideos_VideoId",
                table: "PublishedVideo",
                newName: "IX_PublishedVideo_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_PublishedVideos_ProductId",
                table: "PublishedVideo",
                newName: "IX_PublishedVideo_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "PublishedVideo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishedVideo",
                table: "PublishedVideo",
                column: "PublishedVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedVideo_Products_ProductId",
                table: "PublishedVideo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedVideo_Videos_VideoId",
                table: "PublishedVideo",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
