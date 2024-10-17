using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class IterationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkItems",
                table: "Iterations");

            migrationBuilder.CreateTable(
                name: "IterationWorkItems",
                columns: table => new
                {
                    IterationUid = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkItemsUid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IterationWorkItems", x => new { x.IterationUid, x.WorkItemsUid });
                    table.ForeignKey(
                        name: "FK_IterationWorkItems_Iterations_IterationUid",
                        column: x => x.IterationUid,
                        principalTable: "Iterations",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IterationWorkItems_WorkItems_WorkItemsUid",
                        column: x => x.WorkItemsUid,
                        principalTable: "WorkItems",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IterationWorkItems_WorkItemsUid",
                table: "IterationWorkItems",
                column: "WorkItemsUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IterationWorkItems");

            migrationBuilder.AddColumn<string>(
                name: "WorkItems",
                table: "Iterations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
