using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class university : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AfterXDay",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveSms",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MinSMSCredit",
                table: "Customers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SMSCredit",
                table: "Customers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "SMSCreditCheckDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SMSPass",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SMSUser",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendSmsDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VersionCheckDate",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterXDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActiveSms",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MinSMSCredit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SMSCredit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SMSCreditCheckDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SMSPass",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SMSUser",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SendSmsDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "VersionCheckDate",
                table: "Customers");
        }
    }
}
