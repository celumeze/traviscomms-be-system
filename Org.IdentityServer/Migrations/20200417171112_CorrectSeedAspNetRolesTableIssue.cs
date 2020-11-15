using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.IdentityServer.Migrations
{
    public partial class CorrectSeedAspNetRolesTableIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833583c3-1d58-4b95-baad-05b35acdd6a3",
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd48401-7db4-43e5-ae50-211fa5d87ac8",
                column: "NormalizedName",
                value: "SUBROLE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833583c3-1d58-4b95-baad-05b35acdd6a3",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd48401-7db4-43e5-ae50-211fa5d87ac8",
                column: "NormalizedName",
                value: null);
        }
    }
}
