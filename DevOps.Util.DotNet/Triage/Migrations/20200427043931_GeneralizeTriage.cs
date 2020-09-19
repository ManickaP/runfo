﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOps.Util.Triage.Migrations
{
    public partial class GeneralizeTriage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelTriageIssues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TriageIssueKind = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SearchKind = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SearchText = table.Column<string>(type: "nvarchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTriageIssues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelTriageGitHubIssues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organization = table.Column<string>(nullable: false),
                    Repository = table.Column<string>(nullable: false),
                    IssueNumber = table.Column<int>(nullable: false),
                    ModelTriageIssueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTriageGitHubIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelTriageGitHubIssues_ModelTriageIssues_ModelTriageIssueId",
                        column: x => x.ModelTriageIssueId,
                        principalTable: "ModelTriageIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelTriageIssueResultCompletes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelTriageIssueId = table.Column<int>(nullable: false),
                    ModelBuildId = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTriageIssueResultCompletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelTriageIssueResultCompletes_ModelBuilds_ModelBuildId",
                        column: x => x.ModelBuildId,
                        principalTable: "ModelBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelTriageIssueResultCompletes_ModelTriageIssues_ModelTriageIssueId",
                        column: x => x.ModelTriageIssueId,
                        principalTable: "ModelTriageIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelTriageIssueResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildNumber = table.Column<int>(nullable: false),
                    JobName = table.Column<string>(nullable: true),
                    TimelineRecordName = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    ModelBuildId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ModelTriageIssueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTriageIssueResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelTriageIssueResults_ModelBuilds_ModelBuildId",
                        column: x => x.ModelBuildId,
                        principalTable: "ModelBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelTriageIssueResults_ModelTriageIssues_ModelTriageIssueId",
                        column: x => x.ModelTriageIssueId,
                        principalTable: "ModelTriageIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageGitHubIssues_ModelTriageIssueId",
                table: "ModelTriageGitHubIssues",
                column: "ModelTriageIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageGitHubIssues_Organization_Repository_IssueNumber",
                table: "ModelTriageGitHubIssues",
                columns: new[] { "Organization", "Repository", "IssueNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageIssueResultCompletes_ModelBuildId",
                table: "ModelTriageIssueResultCompletes",
                column: "ModelBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageIssueResultCompletes_ModelTriageIssueId_ModelBuildId",
                table: "ModelTriageIssueResultCompletes",
                columns: new[] { "ModelTriageIssueId", "ModelBuildId" },
                unique: true,
                filter: "[ModelBuildId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageIssueResults_ModelBuildId",
                table: "ModelTriageIssueResults",
                column: "ModelBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageIssueResults_ModelTriageIssueId",
                table: "ModelTriageIssueResults",
                column: "ModelTriageIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTriageIssues_SearchKind_SearchText",
                table: "ModelTriageIssues",
                columns: new[] { "SearchKind", "SearchText" },
                unique: true,
                filter: "[SearchText] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelTriageGitHubIssues");

            migrationBuilder.DropTable(
                name: "ModelTriageIssueResultCompletes");

            migrationBuilder.DropTable(
                name: "ModelTriageIssueResults");

            migrationBuilder.DropTable(
                name: "ModelTriageIssues");
        }
    }
}
