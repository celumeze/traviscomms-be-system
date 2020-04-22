using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravisComms.Data.Repository.Migrations
{
    public partial class UpdateColumnNameAspNetIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientRoleId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderRoleId",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833583c3-1d58-4b95-baad-05b35acdd6a3",
                column: "AccountHolderRoleId",
                value: new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd48401-7db4-43e5-ae50-211fa5d87ac8",
                column: "AccountHolderRoleId",
                value: new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountHolderRoleId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientRoleId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833583c3-1d58-4b95-baad-05b35acdd6a3",
                column: "ClientRoleId",
                value: new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd48401-7db4-43e5-ae50-211fa5d87ac8",
                column: "ClientRoleId",
                value: new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"));
        }
    }
}
