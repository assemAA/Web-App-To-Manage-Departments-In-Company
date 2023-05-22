using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatesinDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "salary",
                table: "Employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salary",
                table: "Employees");
        }
    }
}
