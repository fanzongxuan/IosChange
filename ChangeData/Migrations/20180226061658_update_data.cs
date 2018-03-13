using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class update_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryLevel",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "BatteryStatus",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "CarrierName",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "NetWorkType",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "IDFA",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "IDFV",
                table: "Machine");

            migrationBuilder.RenameColumn(
                name: "WifiName",
                table: "MachineParamter",
                newName: "WifiVendor");

            migrationBuilder.RenameColumn(
                name: "UUID",
                table: "MachineParamter",
                newName: "UserAssignedDeviceName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MachineParamter",
                newName: "UniqueDeviceId");

            migrationBuilder.RenameColumn(
                name: "SystemVersion",
                table: "MachineParamter",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "SystemName",
                table: "MachineParamter",
                newName: "RegionInfo");

            migrationBuilder.RenameColumn(
                name: "ScreenBrightness",
                table: "MachineParamter",
                newName: "RegionCode");

            migrationBuilder.RenameColumn(
                name: "SaleArea",
                table: "MachineParamter",
                newName: "ProductVersion");

            migrationBuilder.RenameColumn(
                name: "ResolutionZoom",
                table: "MachineParamter",
                newName: "ProductType");

            migrationBuilder.RenameColumn(
                name: "Resolution",
                table: "MachineParamter",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MachineParamter",
                newName: "ModelNumber");

            migrationBuilder.RenameColumn(
                name: "MachineTag",
                table: "MachineParamter",
                newName: "MinimumSupportediTunesVersion");

            migrationBuilder.RenameColumn(
                name: "MAC",
                table: "MachineParamter",
                newName: "HardwarePlatform");

            migrationBuilder.RenameColumn(
                name: "LocalName",
                table: "MachineParamter",
                newName: "HWModelStr");

            migrationBuilder.RenameColumn(
                name: "LocalLanguage",
                table: "MachineParamter",
                newName: "FirewareVersion");

            migrationBuilder.RenameColumn(
                name: "IMEI",
                table: "MachineParamter",
                newName: "DeviceVariant");

            migrationBuilder.RenameColumn(
                name: "IDFV",
                table: "MachineParamter",
                newName: "DeviceColor");

            migrationBuilder.RenameColumn(
                name: "IDFA",
                table: "MachineParamter",
                newName: "DeviceClass");

            migrationBuilder.RenameColumn(
                name: "MAC",
                table: "Machine",
                newName: "UniqueDeviceId");

            migrationBuilder.AddColumn<string>(
                name: "ActiveWirelessTechnology",
                table: "MachineParamter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildVersion",
                table: "MachineParamter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CPUArchitecture",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeviceName",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveWirelessTechnology",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "BuildVersion",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "CPUArchitecture",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "MachineParamter");

            migrationBuilder.RenameColumn(
                name: "WifiVendor",
                table: "MachineParamter",
                newName: "WifiName");

            migrationBuilder.RenameColumn(
                name: "UserAssignedDeviceName",
                table: "MachineParamter",
                newName: "UUID");

            migrationBuilder.RenameColumn(
                name: "UniqueDeviceId",
                table: "MachineParamter",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "MachineParamter",
                newName: "SystemVersion");

            migrationBuilder.RenameColumn(
                name: "RegionInfo",
                table: "MachineParamter",
                newName: "SystemName");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "MachineParamter",
                newName: "ScreenBrightness");

            migrationBuilder.RenameColumn(
                name: "ProductVersion",
                table: "MachineParamter",
                newName: "SaleArea");

            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "MachineParamter",
                newName: "ResolutionZoom");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "MachineParamter",
                newName: "Resolution");

            migrationBuilder.RenameColumn(
                name: "ModelNumber",
                table: "MachineParamter",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MinimumSupportediTunesVersion",
                table: "MachineParamter",
                newName: "MachineTag");

            migrationBuilder.RenameColumn(
                name: "HardwarePlatform",
                table: "MachineParamter",
                newName: "MAC");

            migrationBuilder.RenameColumn(
                name: "HWModelStr",
                table: "MachineParamter",
                newName: "LocalName");

            migrationBuilder.RenameColumn(
                name: "FirewareVersion",
                table: "MachineParamter",
                newName: "LocalLanguage");

            migrationBuilder.RenameColumn(
                name: "DeviceVariant",
                table: "MachineParamter",
                newName: "IMEI");

            migrationBuilder.RenameColumn(
                name: "DeviceColor",
                table: "MachineParamter",
                newName: "IDFV");

            migrationBuilder.RenameColumn(
                name: "DeviceClass",
                table: "MachineParamter",
                newName: "IDFA");

            migrationBuilder.RenameColumn(
                name: "UniqueDeviceId",
                table: "Machine",
                newName: "MAC");

            migrationBuilder.AddColumn<float>(
                name: "BatteryLevel",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "BatteryStatus",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "NetWorkType",
                table: "MachineParamter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IDFA",
                table: "Machine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDFV",
                table: "Machine",
                nullable: true);
        }
    }
}
