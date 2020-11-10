using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class EditChannelType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ChangeType_ChangeTypeId",
                table: "ChangeSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeType",
                table: "ChangeType");

            migrationBuilder.RenameTable(
                name: "ChangeType",
                newName: "ChangeTypes");

            migrationBuilder.RenameColumn(
                name: "RequestChanelId",
                table: "RequestChanels",
                newName: "RequestChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeTypes",
                table: "ChangeTypes",
                column: "ChangeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ChangeTypes_ChangeTypeId",
                table: "ChangeSets",
                column: "ChangeTypeId",
                principalTable: "ChangeTypes",
                principalColumn: "ChangeTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ChangeTypes_ChangeTypeId",
                table: "ChangeSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeTypes",
                table: "ChangeTypes");

            migrationBuilder.RenameTable(
                name: "ChangeTypes",
                newName: "ChangeType");

            migrationBuilder.RenameColumn(
                name: "RequestChannelId",
                table: "RequestChanels",
                newName: "RequestChanelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeType",
                table: "ChangeType",
                column: "ChangeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ChangeType_ChangeTypeId",
                table: "ChangeSets",
                column: "ChangeTypeId",
                principalTable: "ChangeType",
                principalColumn: "ChangeTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
