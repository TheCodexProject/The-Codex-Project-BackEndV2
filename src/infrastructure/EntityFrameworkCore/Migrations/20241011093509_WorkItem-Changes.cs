using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class WorkItemChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependenciesIds",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "ResourcesIds",
                table: "WorkItems");

            migrationBuilder.CreateTable(
                name: "WorkItemDependencies",
                columns: table => new
                {
                    DependenciesUid = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkItemUid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemDependencies", x => new { x.DependenciesUid, x.WorkItemUid });
                    table.ForeignKey(
                        name: "FK_WorkItemDependencies_WorkItems_DependenciesUid",
                        column: x => x.DependenciesUid,
                        principalTable: "WorkItems",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItemDependencies_WorkItems_WorkItemUid",
                        column: x => x.WorkItemUid,
                        principalTable: "WorkItems",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemResources",
                columns: table => new
                {
                    ResourcesUid = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkItemUid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemResources", x => new { x.ResourcesUid, x.WorkItemUid });
                    table.ForeignKey(
                        name: "FK_WorkItemResources_Resources_ResourcesUid",
                        column: x => x.ResourcesUid,
                        principalTable: "Resources",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItemResources_WorkItems_WorkItemUid",
                        column: x => x.WorkItemUid,
                        principalTable: "WorkItems",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemDependencies_WorkItemUid",
                table: "WorkItemDependencies",
                column: "WorkItemUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemResources_WorkItemUid",
                table: "WorkItemResources",
                column: "WorkItemUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItemDependencies");

            migrationBuilder.DropTable(
                name: "WorkItemResources");

            migrationBuilder.AddColumn<string>(
                name: "DependenciesIds",
                table: "WorkItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResourcesIds",
                table: "WorkItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
