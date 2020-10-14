using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class services2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requests_RequestId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ContactId",
                table: "Tasks",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Contacts_ContactId",
                table: "Tasks",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Requests_RequestId",
                table: "Tasks",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Contacts_ContactId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requests_RequestId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ContactId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Requests_RequestId",
                table: "Tasks",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
