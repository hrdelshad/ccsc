using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Change_Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Contacts_ContactId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Contracts_ContractId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Duties_DutyId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Servers_ServerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Services_ServiceId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_Id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ContactId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ContractId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DutyId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Id",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_Id");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContactId",
                table: "Comments",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContractId",
                table: "Comments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DutyId",
                table: "Comments",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServerId",
                table: "Comments",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Contacts_ContactId",
                table: "Comments",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Contracts_ContractId",
                table: "Comments",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Duties_DutyId",
                table: "Comments",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "DutyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Servers_ServerId",
                table: "Comments",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "ServerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Services_ServiceId",
                table: "Comments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_Id",
                table: "Comments",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
