using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Gender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalutationId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SalutationId",
                table: "Contacts",
                column: "SalutationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Salutations_SalutationId",
                table: "Contacts",
                column: "SalutationId",
                principalTable: "Salutations",
                principalColumn: "SalutationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Salutations_SalutationId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SalutationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SalutationId",
                table: "Contacts");
        }
    }
}
