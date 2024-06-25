using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class addedConfigFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignStudents_Campaigns_CampaignId",
                schema: "Catalog",
                table: "CampaignStudents");

            migrationBuilder.AddColumn<string>(
                name: "AccountingCode",
                schema: "Catalog",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Catalog",
                table: "Configurations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Catalog",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "Catalog",
                table: "Configurations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Catalog",
                table: "Configurations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxDonationAmount",
                schema: "Catalog",
                table: "Configurations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfStudents",
                schema: "Catalog",
                table: "Configurations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinDonationAmount",
                schema: "Catalog",
                table: "Configurations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinNumberOfStudents",
                schema: "Catalog",
                table: "Configurations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "Catalog",
                table: "Configurations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Catalog",
                table: "Configurations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Catalog",
                table: "Campaigns",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CampaignName",
                schema: "Catalog",
                table: "Campaigns",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignStudents_Campaigns_CampaignId",
                schema: "Catalog",
                table: "CampaignStudents",
                column: "CampaignId",
                principalSchema: "Catalog",
                principalTable: "Campaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignStudents_Campaigns_CampaignId",
                schema: "Catalog",
                table: "CampaignStudents");

            migrationBuilder.DropColumn(
                name: "AccountingCode",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "MaxDonationAmount",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "MaxNumberOfStudents",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "MinDonationAmount",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "MinNumberOfStudents",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Catalog",
                table: "Configurations");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Catalog",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "CampaignName",
                schema: "Catalog",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignStudents_Campaigns_CampaignId",
                schema: "Catalog",
                table: "CampaignStudents",
                column: "CampaignId",
                principalSchema: "Catalog",
                principalTable: "Campaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
