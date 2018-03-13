using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Change.Data.Migrations
{
    public partial class edit_ip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniqueDeviceId",
                table: "Machine",
                newName: "Ip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ip",
                table: "Machine",
                newName: "UniqueDeviceId");
        }
    }
}
