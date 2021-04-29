using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddCustomerStatus1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerStatusId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerStatusId",
                table: "Customers",
                column: "CustomerStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerStatuses_CustomerStatusId",
                table: "Customers",
                column: "CustomerStatusId",
                principalTable: "CustomerStatuses",
                principalColumn: "CustomerStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerStatuses_CustomerStatusId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerStatusId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerStatusId",
                table: "Customers");
        }
    }
}
