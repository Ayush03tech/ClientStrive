using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientStrive_API.Migrations
{
    /// <inheritdoc />
    public partial class ClientProjecttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientProjects",
                columns: table => new
                {
                    ClientProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPersonContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ContactPersonEmailId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalEmpWorking = table.Column<int>(type: "int", nullable: true),
                    ProjectCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProjectDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LeadByEmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProjects", x => x.ClientProjectId);
                    table.ForeignKey(
                        name: "FK_ClientProjects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProjects_Employees_LeadByEmpId",
                        column: x => x.LeadByEmpId,
                        principalTable: "Employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProjects_ClientId",
                table: "ClientProjects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProjects_LeadByEmpId",
                table: "ClientProjects",
                column: "LeadByEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProjects");
        }
    }
}
