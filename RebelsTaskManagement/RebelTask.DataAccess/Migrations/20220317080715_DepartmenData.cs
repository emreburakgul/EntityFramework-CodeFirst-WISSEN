using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTask.DataAccess.Migrations
{
    public partial class DepartmenData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Yazılım kod geliştirme departmanı", "Yazılım" },
                    { 2, "iş analiz ve genel tasarım", "Proje Analiz" },
                    { 3, "Arayüz ve görsel tasarım departmanı", "Grafik ve Arayüz" },
                    { 4, "Yöneticiler Departmanı", "Yönetim" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
