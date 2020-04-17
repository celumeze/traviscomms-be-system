using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravisComms.Data.Repository.Migrations
{
    public partial class AddedIdentityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("9bfe6b2f-6df7-47e5-904e-bcb942f74d60"));

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumn: "ServiceProviderId",
                keyValue: new Guid("f884d1a8-fc85-4975-a518-4167e51534c7"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("042ac2d9-0f4e-4356-8028-093322b66c31"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "SubscriptionTypeId",
                keyValue: new Guid("ad6f9887-86df-4a22-a011-41de506c048f"));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ClientsServiceProviders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ClientsServiceProviders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientRoleId",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ClientRoleId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRole",
                columns: table => new
                {
                    ClientRoleId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRole", x => x.ClientRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientRoleId",
                table: "Clients",
                column: "ClientRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRole_RoleType",
                table: "ClientRole",
                column: "RoleType");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientRole_ClientRoleId",
                table: "Clients",
                column: "ClientRoleId",
                principalTable: "ClientRole",
                principalColumn: "ClientRoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientRole_ClientRoleId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientRole");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientRoleId",
                table: "Clients");

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

            migrationBuilder.DropColumn(
                name: "ClientRoleId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ClientsServiceProviders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ClientsServiceProviders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("9bfe6b2f-6df7-47e5-904e-bcb942f74d60"), "TravisComms\\System", new DateTime(2020, 2, 23, 0, 16, 51, 620, DateTimeKind.Local).AddTicks(6450), null, null, "Twilio" },
                    { new Guid("f884d1a8-fc85-4975-a518-4167e51534c7"), "TravisComms\\System", new DateTime(2020, 2, 23, 0, 16, 51, 625, DateTimeKind.Local).AddTicks(4867), null, null, "Nexmo" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "SubscriptionTypeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("042ac2d9-0f4e-4356-8028-093322b66c31"), "TravisComms\\System", new DateTime(2020, 2, 23, 0, 16, 51, 629, DateTimeKind.Local).AddTicks(1586), null, null, "Trial" },
                    { new Guid("ad6f9887-86df-4a22-a011-41de506c048f"), "TravisComms\\System", new DateTime(2020, 2, 23, 0, 16, 51, 629, DateTimeKind.Local).AddTicks(3691), null, null, "Paid" }
                });
        }
    }
}
