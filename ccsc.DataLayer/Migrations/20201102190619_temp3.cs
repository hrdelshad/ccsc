using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class temp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Users_AppUserId",
                table: "ChangeSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AppUsers_AppUserId",
                table: "ChangeSets",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AppUsers_AppUserId",
                table: "ChangeSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Users_AppUserId",
                table: "ChangeSets",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
