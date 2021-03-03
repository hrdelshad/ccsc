using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ccsc.DataLayer.Migrations
{
	public partial class VideoRelateds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SMSUser",
                table: "Customers",
                newName: "SmsUser");

            migrationBuilder.RenameColumn(
                name: "SMSPass",
                table: "Customers",
                newName: "SmsPass");

            migrationBuilder.RenameColumn(
                name: "SMSCreditCheckDate",
                table: "Customers",
                newName: "SmsCreditCheckDate");

            migrationBuilder.RenameColumn(
                name: "SMSCredit",
                table: "Customers",
                newName: "SmsCredit");

            migrationBuilder.RenameColumn(
                name: "MinSMSCredit",
                table: "Customers",
                newName: "MinSmsCredit");

            migrationBuilder.CreateTable(
                name: "SubSystemVideos",
                columns: table => new
                {
                    SubSystemVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSystemId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    GivenOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSystemVideos", x => x.SubSystemVideoId);
                    table.ForeignKey(
                        name: "FK_SubSystemVideos_SubSystems_SubSystemId",
                        column: x => x.SubSystemId,
                        principalTable: "SubSystems",
                        principalColumn: "SubSystemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubSystemVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeVideos",
                columns: table => new
                {
                    UserTypeVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    GivenOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeVideos", x => x.UserTypeVideoId);
                    table.ForeignKey(
                        name: "FK_UserTypeVideos_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypeVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubSystemVideos_SubSystemId",
                table: "SubSystemVideos",
                column: "SubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSystemVideos_VideoId",
                table: "SubSystemVideos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypeVideos_UserTypeId",
                table: "UserTypeVideos",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypeVideos_VideoId",
                table: "UserTypeVideos",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSystemVideos");

            migrationBuilder.DropTable(
                name: "UserTypeVideos");

            migrationBuilder.RenameColumn(
                name: "SmsUser",
                table: "Customers",
                newName: "SMSUser");

            migrationBuilder.RenameColumn(
                name: "SmsPass",
                table: "Customers",
                newName: "SMSPass");

            migrationBuilder.RenameColumn(
                name: "SmsCreditCheckDate",
                table: "Customers",
                newName: "SMSCreditCheckDate");

            migrationBuilder.RenameColumn(
                name: "SmsCredit",
                table: "Customers",
                newName: "SMSCredit");

            migrationBuilder.RenameColumn(
                name: "MinSmsCredit",
                table: "Customers",
                newName: "MinSMSCredit");
        }
    }
}
