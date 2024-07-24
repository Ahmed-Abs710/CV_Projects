using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_Platform.Migrations
{
    /// <inheritdoc />
    public partial class Newroles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddAdmin",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddStudent",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddTeacher",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelteStudent",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelteTeacher",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendEmail",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateStudent",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateTeacher",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddAdmin",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddStudent",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddTeacher",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DelteStudent",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DelteTeacher",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SendEmail",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateStudent",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateTeacher",
                table: "AspNetRoles");
        }
    }
}
