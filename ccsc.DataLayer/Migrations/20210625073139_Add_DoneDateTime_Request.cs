using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Add_DoneDateTime_Request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.AddColumn<DateTime>(
                name: "DoneDateTime",
                table: "Requests",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropColumn(
                name: "DoneDateTime",
                table: "Requests");
        }
    }
}
