using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Department1.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameProfession = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupervisorName = table.Column<string>(maxLength: 50, nullable: false),
                    departmentId = table.Column<int>(nullable: true),
                    professionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supervisors_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supervisors_professions_professionsId",
                        column: x => x.professionsId,
                        principalTable: "professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkerName = table.Column<string>(nullable: false),
                    departmentId = table.Column<int>(nullable: true),
                    professionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workers_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_workers_professions_professionsId",
                        column: x => x.professionsId,
                        principalTable: "professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supervisors_departmentId",
                table: "supervisors",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_supervisors_professionsId",
                table: "supervisors",
                column: "professionsId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_departmentId",
                table: "workers",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_professionsId",
                table: "workers",
                column: "professionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supervisors");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "professions");
        }
    }
}
