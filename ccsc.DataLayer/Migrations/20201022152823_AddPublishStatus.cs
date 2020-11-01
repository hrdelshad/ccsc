using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddPublishStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AudienceId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "ChangeSets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_AudienceId",
                table: "ChangeSets",
                column: "AudienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Audiences_AudienceId",
                table: "ChangeSets",
                column: "AudienceId",
                principalTable: "Audiences",
                principalColumn: "AudienceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Audiences_AudienceId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_AudienceId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "ChangeSets");
        }
    }
}
