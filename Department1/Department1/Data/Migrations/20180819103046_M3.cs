﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Department1.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supervisors_workers_workersId",
                table: "supervisors");

            migrationBuilder.DropIndex(
                name: "IX_supervisors_workersId",
                table: "supervisors");

            migrationBuilder.DropColumn(
                name: "workersId",
                table: "supervisors");

            migrationBuilder.AddColumn<int>(
                name: "supervisorsId",
                table: "workers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_workers_supervisorsId",
                table: "workers",
                column: "supervisorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_supervisors_supervisorsId",
                table: "workers",
                column: "supervisorsId",
                principalTable: "supervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workers_supervisors_supervisorsId",
                table: "workers");

            migrationBuilder.DropIndex(
                name: "IX_workers_supervisorsId",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "supervisorsId",
                table: "workers");

            migrationBuilder.AddColumn<int>(
                name: "workersId",
                table: "supervisors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supervisors_workersId",
                table: "supervisors",
                column: "workersId");

            migrationBuilder.AddForeignKey(
                name: "FK_supervisors_workers_workersId",
                table: "supervisors",
                column: "workersId",
                principalTable: "workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
