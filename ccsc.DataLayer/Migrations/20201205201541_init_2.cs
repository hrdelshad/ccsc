using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSystemVideos");

            migrationBuilder.DropTable(
                name: "UserTypeVideos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubSystemVideos",
                columns: table => new
                {
                    SubSystemVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GivenOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubSystemId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
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
                    GivenOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
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
    }
}
