using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddVideoToChangeSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_VideoId",
                table: "ChangeSets",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Videos_VideoId",
                table: "ChangeSets",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Videos_VideoId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_VideoId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "ChangeSets");
        }
    }
}
