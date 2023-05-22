using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class secondupdatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_departementid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "departementid",
                table: "Employees",
                newName: "departementId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departementid",
                table: "Employees",
                newName: "IX_Employees_departementId");

            migrationBuilder.AlterColumn<int>(
                name: "departementId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_departementId",
                table: "Employees",
                column: "departementId",
                principalTable: "Departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_departementId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "departementId",
                table: "Employees",
                newName: "departementid");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departementId",
                table: "Employees",
                newName: "IX_Employees_departementid");

            migrationBuilder.AlterColumn<int>(
                name: "departementid",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_departementid",
                table: "Employees",
                column: "departementid",
                principalTable: "Departements",
                principalColumn: "id");
        }
    }
}
