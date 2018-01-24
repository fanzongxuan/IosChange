using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class update_machine_paramters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "MachineParamter");

            migrationBuilder.AlterColumn<int>(
                name: "NetWorkType",
                table: "MachineParamter",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BatteryStatus",
                table: "MachineParamter",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BatteryLevel",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CarrierName",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeviceModel",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryLevel",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "CarrierName",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "MachineParamter");

            migrationBuilder.AlterColumn<string>(
                name: "NetWorkType",
                table: "MachineParamter",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BatteryStatus",
                table: "MachineParamter",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "MachineParamter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "MachineParamter",
                nullable: true);
        }
    }
}
