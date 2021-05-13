using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelMap.Migrations
{
    public partial class AddDiagrams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    NamespaceBelongingTo = table.Column<string>(type: "varchar(128) CHARACTER SET utf8mb4", maxLength: 128, nullable: false),
                    ProjectFullPath = table.Column<string>(type: "varchar(512) CHARACTER SET utf8mb4", maxLength: 512, nullable: false),
                    Directory = table.Column<string>(type: "varchar(512) CHARACTER SET utf8mb4", maxLength: 512, nullable: false),
                    Name = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    BaseClass = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    BaseInterfaces = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", maxLength: 2048, nullable: true),
                    Imports = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", maxLength: 2048, nullable: true),
                    ExtraProperties = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40) CHARACTER SET utf8mb4", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Position_Top = table.Column<double>(type: "double", nullable: false),
                    Position_Left = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDefine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AccessLevel = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    Type = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    GetAccessLevel = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    SetAccessLevel = table.Column<string>(type: "varchar(16) CHARACTER SET utf8mb4", maxLength: 16, nullable: false),
                    EntityDefineId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDefine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyDefine_EntityComponents_EntityDefineId",
                        column: x => x.EntityDefineId,
                        principalTable: "EntityComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityComponents_Position_Left",
                table: "EntityComponents",
                column: "Position_Left");

            migrationBuilder.CreateIndex(
                name: "IX_EntityComponents_Position_Top",
                table: "EntityComponents",
                column: "Position_Top");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDefine_EntityDefineId",
                table: "PropertyDefine",
                column: "EntityDefineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyDefine");

            migrationBuilder.DropTable(
                name: "EntityComponents");
        }
    }
}
