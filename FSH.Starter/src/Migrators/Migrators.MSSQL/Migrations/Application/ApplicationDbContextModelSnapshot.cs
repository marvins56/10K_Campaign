﻿// <auto-generated />
using System;
using FSH.Starter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Catalog")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FSH.Starter.Domain.Catalog.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Brands", "Catalog");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Domain.Catalog.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products", "Catalog");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Campaign", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CampaignId");

                    b.HasIndex("AccountId");

                    b.ToTable("Campaigns", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.CampaignStudent", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CampaignId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CampaignStudents", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Configurations", b =>
                {
                    b.Property<Guid>("ConfigurationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountingCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CampaignId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfigType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfigValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DonationId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MaxDonationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MaxNumberOfStudents")
                        .HasColumnType("int");

                    b.Property<decimal?>("MinDonationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MinNumberOfStudents")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ConfigurationsId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("DonationId");

                    b.ToTable("Configurations", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Donation", b =>
                {
                    b.Property<Guid>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DonationId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("DonorId");

                    b.ToTable("Donations", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.DonationStudent", b =>
                {
                    b.Property<Guid>("DonationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DonationId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("DonationStudents", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Fundraiser", b =>
                {
                    b.Property<Guid>("FundraiserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FundraiserId");

                    b.HasIndex("AccountId");

                    b.ToTable("Fundraisers", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students", "Catalog");
                });

            modelBuilder.Entity("FSH.Starter.Infrastructure.Auditing.Trail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AffectedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AuditTrails", "Auditing");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Infrastructure.Identity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName", "TenantId")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Infrastructure.Identity.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ObjectId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName", "TenantId")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("LoginProvider", "ProviderKey", "TenantId")
                        .IsUnique();

                    b.ToTable("UserLogins", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");

                    b.HasAnnotation("Finbuckle:MultiTenant", true);
                });

            modelBuilder.Entity("FSH.Starter.Domain.Catalog.Product", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Catalog.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Campaign", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Account", "Account")
                        .WithMany("Campaigns")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.CampaignStudent", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Campaign", "Campaign")
                        .WithMany("CampaignStudents")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Student", "Student")
                        .WithMany("CampaignStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Configurations", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Campaign", "Campaign")
                        .WithMany("Configurations")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Donation", "Donation")
                        .WithMany("Configurations")
                        .HasForeignKey("DonationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Donation");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Donation", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Campaign", "Campaign")
                        .WithMany("Donations")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Fundraiser", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.DonationStudent", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Donation", "Donation")
                        .WithMany("DonationStudents")
                        .HasForeignKey("DonationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Student", "Student")
                        .WithMany("DonationStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Fundraiser", b =>
                {
                    b.HasOne("FSH.Starter.Domain.Fundraising.Entities.Account", "Account")
                        .WithMany("Fundraisers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FSH.Starter.Infrastructure.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FSH.Starter.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Account", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Fundraisers");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Campaign", b =>
                {
                    b.Navigation("CampaignStudents");

                    b.Navigation("Configurations");

                    b.Navigation("Donations");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Donation", b =>
                {
                    b.Navigation("Configurations");

                    b.Navigation("DonationStudents");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Fundraiser", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("FSH.Starter.Domain.Fundraising.Entities.Student", b =>
                {
                    b.Navigation("CampaignStudents");

                    b.Navigation("DonationStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
