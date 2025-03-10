﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class added_AppUser_Car_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RoleId",
                table: "Cars",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetRoles_RoleId",
                table: "Cars",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetRoles_RoleId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RoleId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Cars");
        }
    }
}
