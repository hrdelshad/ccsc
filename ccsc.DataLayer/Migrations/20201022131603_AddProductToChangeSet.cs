using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddProductToChangeSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ProductId",
                table: "ChangeSets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Products_ProductId",
                table: "ChangeSets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Products_ProductId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ProductId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ChangeSets");
        }
    }
}
