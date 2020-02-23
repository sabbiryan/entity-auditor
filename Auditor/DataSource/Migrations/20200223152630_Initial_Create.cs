using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSource.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSources",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Department = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSources", x => x.SocialSecurityNumber);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTargets",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Department = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTargets", x => x.SocialSecurityNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSources");

            migrationBuilder.DropTable(
                name: "EmployeeTargets");
        }
    }
}
