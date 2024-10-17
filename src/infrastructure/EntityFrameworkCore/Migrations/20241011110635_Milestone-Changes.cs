using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class MilestoneChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkItems",
                table: "Milestones");

            migrationBuilder.CreateTable(
                name: "MilestoneWorkItems",
                columns: table => new
                {
                    MilestoneUid = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkItemsUid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestoneWorkItems", x => new { x.MilestoneUid, x.WorkItemsUid });
                    table.ForeignKey(
                        name: "FK_MilestoneWorkItems_Milestones_MilestoneUid",
                        column: x => x.MilestoneUid,
                        principalTable: "Milestones",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilestoneWorkItems_WorkItems_WorkItemsUid",
                        column: x => x.WorkItemsUid,
                        principalTable: "WorkItems",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneWorkItems_WorkItemsUid",
                table: "MilestoneWorkItems",
                column: "WorkItemsUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilestoneWorkItems");

            migrationBuilder.AddColumn<string>(
                name: "WorkItems",
                table: "Milestones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
