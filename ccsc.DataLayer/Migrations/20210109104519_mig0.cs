using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class mig0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_ServiceTypes_ParentServiceTypeId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_ParentServiceTypeId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "ParentServiceTypeId",
                table: "ServiceTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentServiceTypeId",
                table: "ServiceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ParentServiceTypeId",
                table: "ServiceTypes",
                column: "ParentServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_ServiceTypes_ParentServiceTypeId",
                table: "ServiceTypes",
                column: "ParentServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
