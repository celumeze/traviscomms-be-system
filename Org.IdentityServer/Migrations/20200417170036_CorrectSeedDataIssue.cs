using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.IdentityServer.Migrations
{
    public partial class CorrectSeedDataIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab7b1a88-805c-4f29-9dea-591d5697138b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5299393-bfbb-41b1-9a5e-c74b7634adb4");

            migrationBuilder.UpdateData(
                table: "AccountHoldersRole",
                keyColumn: "AccountHolderRoleId",
                keyValue: new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AccountHoldersRole",
                keyColumn: "AccountHolderRoleId",
                keyValue: new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ClientRoleId", "ConcurrencyStamp", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833583c3-1d58-4b95-baad-05b35acdd6a3", new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"), "ef51e739-98e5-4455-9ae0-061ebfdda460", "TravisComms\\System", new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified), null, null, "Admin", null },
                    { "ebd48401-7db4-43e5-ae50-211fa5d87ac8", new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"), "be15a41d-2400-45cf-bb50-9c6394d9ef25", "TravisComms\\System", new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified), null, null, "SubRole", null }
                });

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("360cf2ed-3705-4248-a4a4-b15c8a3077de"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("55404fe5-0ff5-4cae-9b30-69263baf424f"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833583c3-1d58-4b95-baad-05b35acdd6a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd48401-7db4-43e5-ae50-211fa5d87ac8");

            migrationBuilder.UpdateData(
                table: "AccountHoldersRole",
                keyColumn: "AccountHolderRoleId",
                keyValue: new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 126, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "AccountHoldersRole",
                keyColumn: "AccountHolderRoleId",
                keyValue: new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 125, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ClientRoleId", "ConcurrencyStamp", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e5299393-bfbb-41b1-9a5e-c74b7634adb4", new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"), "d98bc5ab-29e3-458e-afdd-52bccada96cb", "TravisComms\\System", new DateTime(2020, 4, 17, 17, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 17, 17, 57, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { "ab7b1a88-805c-4f29-9dea-591d5697138b", new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"), "80a8fe61-a8ec-4250-ae7a-fc3129de8a35", "TravisComms\\System", new DateTime(2020, 4, 17, 17, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 17, 17, 57, 0, 0, DateTimeKind.Unspecified), null, "SubRole", null }
                });

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 116, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 121, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 121, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("360cf2ed-3705-4248-a4a4-b15c8a3077de"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 123, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("55404fe5-0ff5-4cae-9b30-69263baf424f"),
                column: "DateCreated",
                value: new DateTime(2020, 4, 17, 17, 50, 25, 124, DateTimeKind.Local).AddTicks(2728));
        }
    }
}
