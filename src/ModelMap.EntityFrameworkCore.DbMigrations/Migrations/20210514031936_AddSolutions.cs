using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelMap.Migrations
{
    public partial class AddSolutions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDefine_EntityComponents_EntityDefineId",
                table: "PropertyDefine");

            migrationBuilder.RenameColumn(
                name: "EntityDefineId",
                table: "PropertyDefine",
                newName: "EntityComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDefine_EntityDefineId",
                table: "PropertyDefine",
                newName: "IX_PropertyDefine_EntityComponentId");

            migrationBuilder.RenameColumn(
                name: "ProjectFullPath",
                table: "EntityComponents",
                newName: "ProjectRelativePath");

            migrationBuilder.AddColumn<Guid>(
                name: "SolutionId",
                table: "EntityComponents",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AbsolutePath = table.Column<string>(type: "varchar(1000) CHARACTER SET utf8mb4", maxLength: 1000, nullable: false),
                    ExtraProperties = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40) CHARACTER SET utf8mb4", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDefine_EntityComponents_EntityComponentId",
                table: "PropertyDefine",
                column: "EntityComponentId",
                principalTable: "EntityComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDefine_EntityComponents_EntityComponentId",
                table: "PropertyDefine");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropColumn(
                name: "SolutionId",
                table: "EntityComponents");

            migrationBuilder.RenameColumn(
                name: "EntityComponentId",
                table: "PropertyDefine",
                newName: "EntityDefineId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDefine_EntityComponentId",
                table: "PropertyDefine",
                newName: "IX_PropertyDefine_EntityDefineId");

            migrationBuilder.RenameColumn(
                name: "ProjectRelativePath",
                table: "EntityComponents",
                newName: "ProjectFullPath");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDefine_EntityComponents_EntityDefineId",
                table: "PropertyDefine",
                column: "EntityDefineId",
                principalTable: "EntityComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
