using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravisComms.Data.Repository.Migrations
{
    public partial class AddedActiveColToClientUpdateRoleDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientRole",
                keyColumn: "ClientRoleId",
                keyValue: new Guid("43eb4c75-edc7-4c7c-a688-097b907f9296"));

            migrationBuilder.DeleteData(
                table: "ClientRole",
                keyColumn: "ClientRoleId",
                keyValue: new Guid("d34b5713-4971-44e2-9da8-cad308b9f881"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("06f547aa-1f55-4046-9591-4543457f52ea"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("35194f47-dfe0-4322-98ca-a992e88be42a"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("975dbbe2-2e3e-4e2e-b406-fe7e865bb8e0"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("a266302e-4baf-4069-bb10-380c412a4dff"));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Clients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ClientRole",
                columns: new[] { "ClientRoleId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "RoleType" },
                values: new object[,]
                {
                    { new Guid("52273c16-bd56-4d9d-87a4-8af458f0d2d6"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 853, DateTimeKind.Local).AddTicks(5227), null, null, 1 },
                    { new Guid("aad9db2c-1789-4514-aaf3-0bd737de8bb3"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 853, DateTimeKind.Local).AddTicks(6921), null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("e10737fc-611f-4f54-a024-cc18ae2ce936"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 825, DateTimeKind.Local).AddTicks(472), null, null, "Twilio" },
                    { new Guid("3e9f944e-fbef-44fa-a9e1-0c008745fe44"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 850, DateTimeKind.Local).AddTicks(1456), null, null, "Nexmo" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "SubscriptionTypeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("21fbe8f2-b44f-4f25-ba90-9d05f769c180"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 852, DateTimeKind.Local).AddTicks(9767), null, null, "Trial" },
                    { new Guid("dcfb58e9-a88d-4200-94b5-5e38489e5158"), "TravisComms\\System", new DateTime(2020, 2, 25, 1, 13, 35, 853, DateTimeKind.Local).AddTicks(1585), null, null, "Paid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientRole",
                keyColumn: "ClientRoleId",
                keyValue: new Guid("52273c16-bd56-4d9d-87a4-8af458f0d2d6"));

            migrationBuilder.DeleteData(
                table: "ClientRole",
                keyColumn: "ClientRoleId",
                keyValue: new Guid("aad9db2c-1789-4514-aaf3-0bd737de8bb3"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("3e9f944e-fbef-44fa-a9e1-0c008745fe44"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("e10737fc-611f-4f54-a024-cc18ae2ce936"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("21fbe8f2-b44f-4f25-ba90-9d05f769c180"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("dcfb58e9-a88d-4200-94b5-5e38489e5158"));

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Clients");

            migrationBuilder.InsertData(
                table: "ClientRole",
                columns: new[] { "ClientRoleId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "RoleType" },
                values: new object[,]
                {
                    { new Guid("d34b5713-4971-44e2-9da8-cad308b9f881"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 835, DateTimeKind.Local).AddTicks(2833), null, null, 1 },
                    { new Guid("43eb4c75-edc7-4c7c-a688-097b907f9296"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 835, DateTimeKind.Local).AddTicks(4401), null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("35194f47-dfe0-4322-98ca-a992e88be42a"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 829, DateTimeKind.Local).AddTicks(9720), null, null, "Twilio" },
                    { new Guid("06f547aa-1f55-4046-9591-4543457f52ea"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 833, DateTimeKind.Local).AddTicks(1159), null, null, "Nexmo" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "SubscriptionTypeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("a266302e-4baf-4069-bb10-380c412a4dff"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 834, DateTimeKind.Local).AddTicks(8534), null, null, "Trial" },
                    { new Guid("975dbbe2-2e3e-4e2e-b406-fe7e865bb8e0"), "TravisComms\\System", new DateTime(2020, 2, 23, 22, 20, 1, 834, DateTimeKind.Local).AddTicks(9920), null, null, "Paid" }
                });
        }
    }
}
