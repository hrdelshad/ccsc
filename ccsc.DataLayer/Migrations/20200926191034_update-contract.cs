using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class updatecontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Contracts_ContractId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Contracts_ContractId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ContractId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ContractId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contracts",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ContractCourses",
                columns: table => new
                {
                    ContractCoursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCourses", x => x.ContractCoursId);
                    table.ForeignKey(
                        name: "FK_ContractCourses_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractProducts",
                columns: table => new
                {
                    ContractProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProducts", x => x.ContractProductId);
                    table.ForeignKey(
                        name: "FK_ContractProducts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourses_ContractId",
                table: "ContractCourses",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourses_CourseId",
                table: "ContractCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProducts_ContractId",
                table: "ContractProducts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProducts_ProductId",
                table: "ContractProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractCourses");

            migrationBuilder.DropTable(
                name: "ContractProducts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    CustomerProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => x.CustomerProductId);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ContractId",
                table: "Products",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ContractId",
                table: "Courses",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ContractId",
                table: "CustomerProducts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ProductId",
                table: "CustomerProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Contracts_ContractId",
                table: "Courses",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Contracts_ContractId",
                table: "Products",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
