using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.IdentityServer.Migrations
{
    public partial class RemovedAccountHolderServiceProviders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHolders_AccountHoldersServiceProviders_AccountHolderServiceProviderId",
                table: "AccountHolders");

            migrationBuilder.DropTable(
                name: "AccountHoldersServiceProviders");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_AccountHolders_AccountHolderServiceProviderId",
                table: "AccountHolders");

            migrationBuilder.DropColumn(
                name: "AccountHolderServiceProviderId",
                table: "AccountHolders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountHolderServiceProviderId",
                table: "AccountHolders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.ServiceProviderId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHoldersServiceProviders",
                columns: table => new
                {
                    AccountHolderServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AccountHoldersServiceProviders", x => x.AccountHolderServiceProviderId);
                    table.ForeignKey(
                        name: "FK_AccountHoldersServiceProviders_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"), "TravisComms\\System", new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified), null, null, "Twilio" });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"), "TravisComms\\System", new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified), null, null, "Vonage" });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ServiceProviderId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"), "TravisComms\\System", new DateTime(2020, 4, 17, 18, 15, 0, 0, DateTimeKind.Unspecified), null, null, "Whatsapp" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_AccountHolderServiceProviderId",
                table: "AccountHolders",
                column: "AccountHolderServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHoldersServiceProviders_ServiceProviderId",
                table: "AccountHoldersServiceProviders",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHolders_AccountHoldersServiceProviders_AccountHolderServiceProviderId",
                table: "AccountHolders",
                column: "AccountHolderServiceProviderId",
                principalTable: "AccountHoldersServiceProviders",
                principalColumn: "AccountHolderServiceProviderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
