using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddCustomerIdToFaqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CustomerId",
                table: "Faqs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Customers_CustomerId",
                table: "Faqs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Customers_CustomerId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_CustomerId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Faqs");
        }
    }
}
