using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class add_EnableMachineParaters_fileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineParamter_Machine_MachineId",
                table: "MachineParamter");

            migrationBuilder.RenameColumn(
                name: "IsInUse",
                table: "MachineParamter",
                newName: "Enable");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MachineParamter",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableMachineParaters",
                table: "Machine",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineParamter_Machine_MachineId",
                table: "MachineParamter",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineParamter_Machine_MachineId",
                table: "MachineParamter");

            migrationBuilder.DropColumn(
                name: "EnableMachineParaters",
                table: "Machine");

            migrationBuilder.RenameColumn(
                name: "Enable",
                table: "MachineParamter",
                newName: "IsInUse");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MachineParamter",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MachineParamter_Machine_MachineId",
                table: "MachineParamter",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
