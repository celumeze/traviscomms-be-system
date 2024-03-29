﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravisComms.Data.Repository;

namespace TravisComms.Data.Repository.Migrations
{
    [DbContext(typeof(TravisCommsSqlDbContext))]
    [Migration("20200417161122_ChangedClientToAccountHolder")]
    partial class ChangedClientToAccountHolder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.AccountHolder", b =>
                {
                    b.Property<Guid>("AccountHolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountHolderRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountHolderServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("IsAccountDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountHolderId");

                    b.HasIndex("AccountHolderRoleId");

                    b.HasIndex("AccountHolderServiceProviderId");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("AccountHolders");
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.AccountHolderRole", b =>
                {
                    b.Property<Guid>("AccountHolderRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("AccountHolderRoleId");

                    b.HasIndex("RoleType");

                    b.ToTable("AccountHoldersRole");

                    b.HasData(
                        new
                        {
                            AccountHolderRoleId = new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(8186),
                            RoleType = 1
                        },
                        new
                        {
                            AccountHolderRoleId = new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(9619),
                            RoleType = 2
                        });
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.AccountHolderServiceProvider", b =>
                {
                    b.Property<Guid>("AccountHolderServiceProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountSid")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<Guid>("ServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountHolderServiceProviderId");

                    b.HasIndex("ServiceProviderId");

                    b.ToTable("AccountHoldersServiceProviders");
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.HasKey("CompanyId");

                    b.HasIndex("AccountHolderId");

                    b.HasIndex("Name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.ServiceProvider", b =>
                {
                    b.Property<Guid>("ServiceProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceProviderId");

                    b.ToTable("ServiceProviders");

                    b.HasData(
                        new
                        {
                            ServiceProviderId = new Guid("3f6625ae-9fca-4975-99c2-2ca362e55825"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 99, DateTimeKind.Local).AddTicks(8779),
                            Name = "Twilio"
                        },
                        new
                        {
                            ServiceProviderId = new Guid("8b07f619-cff8-4795-9a22-cbca1493cf02"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 195, DateTimeKind.Local).AddTicks(2222),
                            Name = "Vonage"
                        },
                        new
                        {
                            ServiceProviderId = new Guid("873c3886-ce7d-42bd-b48c-05f41b36212f"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 195, DateTimeKind.Local).AddTicks(2304),
                            Name = "Whatsapp"
                        });
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.SubscriptionType", b =>
                {
                    b.Property<Guid>("SubscriptionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<int>("PeriodInDays")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SubscriptionTypeId");

                    b.HasIndex("Name");

                    b.ToTable("SubscriptionTypes");

                    b.HasData(
                        new
                        {
                            SubscriptionTypeId = new Guid("360cf2ed-3705-4248-a4a4-b15c8a3077de"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(635),
                            Name = "Trial",
                            PeriodInDays = 2,
                            Price = 0m
                        },
                        new
                        {
                            SubscriptionTypeId = new Guid("55404fe5-0ff5-4cae-9b30-69263baf424f"),
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 197, DateTimeKind.Local).AddTicks(3461),
                            Name = "Paid",
                            PeriodInDays = 31,
                            Price = 45m
                        });
                });

            modelBuilder.Entity("TravisComms.Data.Repository.IdentityModels.MainRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ClientRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "eff0800d-c45c-47af-b7ca-5e9b856300fa",
                            ClientRoleId = new Guid("cb0a792b-bf55-46b5-8795-10c43006be92"),
                            ConcurrencyStamp = "63f8a2f5-18b9-44b3-b8ee-be70d37e1cd4",
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 198, DateTimeKind.Local).AddTicks(1116),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "4c145e45-b261-47b7-8c26-4bf144106092",
                            ClientRoleId = new Guid("37c9973f-9436-4f49-89ef-1e7b2d2398e4"),
                            ConcurrencyStamp = "4a045598-dad4-4c72-a400-8c5f6144f92b",
                            CreatedBy = "TravisComms\\System",
                            DateCreated = new DateTime(2020, 4, 17, 17, 11, 21, 198, DateTimeKind.Local).AddTicks(6714),
                            Name = "SubRole"
                        });
                });

            modelBuilder.Entity("TravisComms.Data.Repository.IdentityModels.MainUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravisComms.Data.Repository.IdentityModels.MainUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.AccountHolder", b =>
                {
                    b.HasOne("TravisComms.Data.Entities.Models.AccountHolderRole", "AccountHolderRole")
                        .WithMany("AccountHolders")
                        .HasForeignKey("AccountHolderRoleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TravisComms.Data.Entities.Models.AccountHolderServiceProvider", "AccountHolderServiceProvider")
                        .WithMany()
                        .HasForeignKey("AccountHolderServiceProviderId");

                    b.HasOne("TravisComms.Data.Entities.Models.SubscriptionType", "SubscriptionType")
                        .WithMany("AccountHolders")
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.AccountHolderServiceProvider", b =>
                {
                    b.HasOne("TravisComms.Data.Entities.Models.ServiceProvider", "ServiceProvider")
                        .WithMany("AccountHolderServiceProviders")
                        .HasForeignKey("ServiceProviderId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravisComms.Data.Entities.Models.Company", b =>
                {
                    b.HasOne("TravisComms.Data.Entities.Models.AccountHolder", null)
                        .WithMany("Companies")
                        .HasForeignKey("AccountHolderId");
                });
#pragma warning restore 612, 618
        }
    }
}
