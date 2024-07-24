using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses_Service.Migrations
{
    /// <inheritdoc />
    public partial class couroic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoursePic",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursePic",
                table: "courses");
        }
    }
}
