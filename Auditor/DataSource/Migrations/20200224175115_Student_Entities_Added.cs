using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSource.Migrations
{
    public partial class Student_Entities_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSources",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSources", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentTargets",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTargets", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSources");

            migrationBuilder.DropTable(
                name: "StudentTargets");
        }
    }
}
