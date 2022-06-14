using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTask.DataAccess.Migrations
{
    public partial class employeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    LeaveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FirstName", "HireDate", "LastName", "LeaveDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Jason", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Statham", null, "Yazılım geliştirici" },
                    { 2, 1, "Arnold", new DateTime(2015, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swatcz", null, "Yazılım geliştirici" },
                    { 3, 1, "Bruce", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wayne", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım geliştirici" },
                    { 4, 2, "Bryy", new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allan", null, "İş analisti" },
                    { 5, 2, "Mark", new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buffalo", new DateTime(2015, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "İş analisti" },
                    { 6, 3, "Elvis", new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Presley", null, "Grafik tasarımc" },
                    { 7, 4, "Freddie", new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercury", null, "Proje Yöneticisi" },
                    { 8, 4, "Alan", new DateTime(2011, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walker", null, "Ar-ge yöneticisi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
