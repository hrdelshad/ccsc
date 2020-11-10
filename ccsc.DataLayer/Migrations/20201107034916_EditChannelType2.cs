using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class EditChannelType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestChanels_RequestChanelId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestChanels",
                table: "RequestChanels");

            migrationBuilder.RenameTable(
                name: "RequestChanels",
                newName: "RequestChannels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestChannels",
                table: "RequestChannels",
                column: "RequestChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestChannels_RequestChanelId",
                table: "Requests",
                column: "RequestChanelId",
                principalTable: "RequestChannels",
                principalColumn: "RequestChannelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestChannels_RequestChanelId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestChannels",
                table: "RequestChannels");

            migrationBuilder.RenameTable(
                name: "RequestChannels",
                newName: "RequestChanels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestChanels",
                table: "RequestChanels",
                column: "RequestChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestChanels_RequestChanelId",
                table: "Requests",
                column: "RequestChanelId",
                principalTable: "RequestChanels",
                principalColumn: "RequestChannelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
