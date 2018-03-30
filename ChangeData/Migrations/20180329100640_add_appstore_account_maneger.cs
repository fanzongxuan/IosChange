using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class add_appstore_account_maneger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormateDateString",
                table: "ReUseRecord");

            migrationBuilder.CreateTable(
                name: "AppStoreAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UseTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStoreAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountUserRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppStoreAccountId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserRecord_AppStoreAccount_AppStoreAccountId",
                        column: x => x.AppStoreAccountId,
                        principalTable: "AppStoreAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRecord_AppStoreAccountId",
                table: "AccountUserRecord",
                column: "AppStoreAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUserRecord");

            migrationBuilder.DropTable(
                name: "AppStoreAccount");

            migrationBuilder.AddColumn<string>(
                name: "FormateDateString",
                table: "ReUseRecord",
                nullable: true);
        }
    }
}
