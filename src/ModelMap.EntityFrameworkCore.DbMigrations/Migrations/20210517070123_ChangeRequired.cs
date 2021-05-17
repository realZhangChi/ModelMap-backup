using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelMap.Migrations
{
    public partial class ChangeRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imports",
                table: "EntityComponents",
                type: "varchar(2048) CHARACTER SET utf8mb4",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseInterfaces",
                table: "EntityComponents",
                type: "varchar(2048) CHARACTER SET utf8mb4",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseClass",
                table: "EntityComponents",
                type: "varchar(16) CHARACTER SET utf8mb4",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(16) CHARACTER SET utf8mb4",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imports",
                table: "EntityComponents",
                type: "longtext CHARACTER SET utf8mb4",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2048) CHARACTER SET utf8mb4",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseInterfaces",
                table: "EntityComponents",
                type: "longtext CHARACTER SET utf8mb4",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2048) CHARACTER SET utf8mb4",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseClass",
                table: "EntityComponents",
                type: "varchar(16) CHARACTER SET utf8mb4",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(16) CHARACTER SET utf8mb4",
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
