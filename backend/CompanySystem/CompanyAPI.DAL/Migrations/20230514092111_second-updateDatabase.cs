using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class secondupdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_dept_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_dept_id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "dept_id",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "departementid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departementid",
                table: "Employees",
                column: "departementid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_departementid",
                table: "Employees",
                column: "departementid",
                principalTable: "Departements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_departementid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departementid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departementid",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "dept_id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_dept_id",
                table: "Employees",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_dept_id",
                table: "Employees",
                column: "dept_id",
                principalTable: "Departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
