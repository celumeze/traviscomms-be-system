using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.IdentityServer.Migrations
{
    public partial class ChangedClientToAccountHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Clients_ClientId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientRole");

            migrationBuilder.DropTable(
                name: "ClientsServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ClientId",
                table: "Companies");

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
                name: "ClientId",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubscriptionTypes",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeriodInDays",
                table: "SubscriptionTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SubscriptionTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AspNetRoles",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccountHoldersRole",
                columns: table => new
                {
                    AccountHolderRoleId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHoldersRole", x => x.AccountHolderRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHoldersServiceProviders",
                columns: table => new
                {
                    AccountHolderServiceProviderId = table.Column<Guid>(nullable: false),
                    AuthToken = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    AccountSid = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ServiceProviderId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHoldersServiceProviders", x => x.AccountHolderServiceProviderId);
                    table.ForeignKey(
                        name: "FK_AccountHoldersServiceProviders_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountHolders",
                columns: table => new
                {
                    AccountHolderId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsAccountDeleted = table.Column<bool>(nullable: false),
                    SubscriptionTypeId = table.Column<Guid>(nullable: false),
                    AccountHolderRoleId = table.Column<Guid>(nullable: false),
                    AccountHolderServiceProviderId = table.Column<Guid>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolders", x => x.AccountHolderId);
                    table.ForeignKey(
                        name: "FK_AccountHolders_AccountHoldersRole_AccountHolderRoleId",
                        column: x => x.AccountHolderRoleId,
                        principalTable: "AccountHoldersRole",
                        principalColumn: "AccountHolderRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountHolders_AccountHoldersServiceProviders_AccountHolderServiceProviderId",
                        column: x => x.AccountHolderServiceProviderId,
                        principalTable: "AccountHoldersServiceProviders",
                        principalColumn: "AccountHolderServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountHolders_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "SubscriptionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountHoldersRole",
                columns: new[] { "AccountHolderRoleId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "RoleType" },
                values: new object[,]
                {
                    { new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(8186), null, null, 1 },
                    { new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(9619), null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ClientRoleId", "ConcurrencyStamp", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eff0800d-c45c-47af-b7ca-5e9b856300fa", new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"), "63f8a2f5-18b9-44b3-b8ee-be70d37e1cd4", "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 198, DateTimeKind.Local).AddTicks(1116), null, null, "Admin", null },
                    { "4c145e45-b261-47b7-8c26-4bf144106092", new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"), "4a045598-dad4-4c72-a400-8c5f6144f92b", "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 198, DateTimeKind.Local).AddTicks(6714), null, null, "SubRole", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 99, DateTimeKind.Local).AddTicks(8779), null, null, "Twilio" },
                    { new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 195, DateTimeKind.Local).AddTicks(2222), null, null, "Vonage" },
                    { new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 195, DateTimeKind.Local).AddTicks(2304), null, null, "Whatsapp" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "SubscriptionTypeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "PeriodInDays", "Price" },
                values: new object[,]
                {
                    { new Guid("360cf2ed-3705-4248-a4a4-b15c8a3077de"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(635), null, null, "Trial", 2, 0m },
                    { new Guid("55404fe5-0ff5-4cae-9b30-69263baf424f"), "TravisComms\\System", new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(3461), null, null, "Paid", 31, 45m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionTypes_Name",
                table: "SubscriptionTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AccountHolderId",
                table: "Companies",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_AccountHolderRoleId",
                table: "AccountHolders",
                column: "AccountHolderRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_AccountHolderServiceProviderId",
                table: "AccountHolders",
                column: "AccountHolderServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_SubscriptionTypeId",
                table: "AccountHolders",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHoldersRole_RoleType",
                table: "AccountHoldersRole",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHoldersServiceProviders_ServiceProviderId",
                table: "AccountHoldersServiceProviders",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AccountHolders_AccountHolderId",
                table: "Companies",
                column: "AccountHolderId",
                principalTable: "AccountHolders",
                principalColumn: "AccountHolderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AccountHolders_AccountHolderId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "AccountHolders");

            migrationBuilder.DropTable(
                name: "AccountHoldersRole");

            migrationBuilder.DropTable(
                name: "AccountHoldersServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionTypes_Name",
                table: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AccountHolderId",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c145e45-b261-47b7-8c26-4bf144106092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff0800d-c45c-47af-b7ca-5e9b856300fa");

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("360cf2ed-3705-4248-a4a4-b15c8a3077de"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("55404fe5-0ff5-4cae-9b30-69263baf424f"));

            migrationBuilder.DropColumn(
                name: "PeriodInDays",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubscriptionTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ClientRole",
                columns: table => new
                {
                    ClientRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRole", x => x.ClientRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ClientsServiceProviders",
                columns: table => new
                {
                    ClientServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountSid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AuthToken = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsServiceProviders", x => x.ClientServiceProviderId);
                    table.ForeignKey(
                        name: "FK_ClientsServiceProviders_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClientRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_ClientRole_ClientRoleId",
                        column: x => x.ClientRoleId,
                        principalTable: "ClientRole",
                        principalColumn: "ClientRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_ClientsServiceProviders_ClientServiceProviderId",
                        column: x => x.ClientServiceProviderId,
                        principalTable: "ClientsServiceProviders",
                        principalColumn: "ClientServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "SubscriptionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ClientId",
                table: "Companies",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRole_RoleType",
                table: "ClientRole",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientRoleId",
                table: "Clients",
                column: "ClientRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientServiceProviderId",
                table: "Clients",
                column: "ClientServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SubscriptionTypeId",
                table: "Clients",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsServiceProviders_ServiceProviderId",
                table: "ClientsServiceProviders",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Clients_ClientId",
                table: "Companies",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
