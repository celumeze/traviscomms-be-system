using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravisComms.Data.Repository.Migrations
{
    public partial class AddedRegistrationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ServiceProviderId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.ServiceProviderId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTypes",
                columns: table => new
                {
                    SubscriptionTypeId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTypes", x => x.SubscriptionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClientsServiceProviders",
                columns: table => new
                {
                    ClientServiceProviderId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    AuthToken = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    AccountSid = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ServiceProviderId = table.Column<Guid>(nullable: false)
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
                    ClientId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SubscriptionTypeId = table.Column<Guid>(nullable: false),
                    ClientServiceProviderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
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

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    ClientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ClientId",
                table: "Companies",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientsServiceProviders");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes");

            migrationBuilder.DropTable(
                name: "ServiceProviders");
        }
    }
}
