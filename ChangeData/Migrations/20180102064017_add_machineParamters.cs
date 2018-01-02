using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class add_machineParamters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineParamter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BatteryStatus = table.Column<string>(nullable: true),
                    ConnectionType = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IDFA = table.Column<string>(nullable: true),
                    IDFV = table.Column<string>(nullable: true),
                    IMEI = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsInUse = table.Column<bool>(nullable: false),
                    LocalLanguage = table.Column<string>(nullable: true),
                    LocalName = table.Column<string>(nullable: true),
                    MAC = table.Column<string>(nullable: true),
                    MachineId = table.Column<int>(nullable: true),
                    MachineTag = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NetWorkType = table.Column<string>(nullable: true),
                    Operator = table.Column<string>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    ResolutionZoom = table.Column<string>(nullable: true),
                    SaleArea = table.Column<string>(nullable: true),
                    ScreenBrightness = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    SystemVersion = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UUID = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    WifiName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineParamter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineParamter_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineParamter_MachineId",
                table: "MachineParamter",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineParamter");
        }
    }
}
