using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class add_isactive_in_fag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Faqs");
        }
    }
}
