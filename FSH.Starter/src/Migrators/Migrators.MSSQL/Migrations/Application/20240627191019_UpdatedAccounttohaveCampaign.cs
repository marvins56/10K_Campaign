using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class UpdatedAccounttohaveCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "Catalog",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AccountId",
                schema: "Catalog",
                table: "Campaigns",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Accounts_AccountId",
                schema: "Catalog",
                table: "Campaigns",
                column: "AccountId",
                principalSchema: "Catalog",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Accounts_AccountId",
                schema: "Catalog",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_AccountId",
                schema: "Catalog",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "Catalog",
                table: "Campaigns");
        }
    }
}
