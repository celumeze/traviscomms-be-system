using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.IdentityServer.Migrations
{
    public partial class AddUpgradeAttrForHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpgrade",
                table: "AccountHolders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsUpgradedToPaid",
                table: "AccountHolders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfUpgrade",
                table: "AccountHolders");

            migrationBuilder.DropColumn(
                name: "IsUpgradedToPaid",
                table: "AccountHolders");
        }
    }
}
