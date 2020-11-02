using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class temp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Users_AppUserUserId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_AppUserUserId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "AppUserUserId",
                table: "ChangeSets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChangeSets",
                newName: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_AppUserId",
                table: "ChangeSets",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Users_AppUserId",
                table: "ChangeSets",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Users_AppUserId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_AppUserId",
                table: "ChangeSets");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ChangeSets",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserUserId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_AppUserUserId",
                table: "ChangeSets",
                column: "AppUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Users_AppUserUserId",
                table: "ChangeSets",
                column: "AppUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
