using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class add_product_record : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppName = table.Column<string>(nullable: true),
                    BundleId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyProductionRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductionRecordId = table.Column<int>(nullable: false),
                    Times = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyProductionRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyProductionRecord_ProductionRecord_ProductionRecordId",
                        column: x => x.ProductionRecordId,
                        principalTable: "ProductionRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProductionRecord_ProductionRecordId",
                table: "DailyProductionRecord",
                column: "ProductionRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyProductionRecord");

            migrationBuilder.DropTable(
                name: "ProductionRecord");
        }
    }
}
