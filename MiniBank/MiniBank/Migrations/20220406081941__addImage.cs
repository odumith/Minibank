using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBank.Migrations
{
    public partial class _addImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "KYCModels",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "KYCModels");
        }
    }
}
