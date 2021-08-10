﻿// <auto-generated />
using System;
using DevOps.Util.DotNet.Triage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevOps.Util.DotNet.Triage.Migrations
{
    [DbContext(typeof(TriageContext))]
    partial class TriageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AzureOrganization")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AzureProject")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BuildKind")
                        .HasColumnType("int");

                    b.Property<int>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<int>("BuildResult")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DefinitionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GitHubOrganization")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GitHubRepository")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GitHubTargetBranch")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PullRequestNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("QueueTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.HasIndex("NameKey")
                        .IsUnique();

                    b.HasIndex("StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.HasIndex("DefinitionName", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.HasIndex("DefinitionNumber", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.ToTable("ModelBuilds");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<int>("BuildKind")
                        .HasColumnType("int");

                    b.Property<int>("BuildResult")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DefinitionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GitHubTargetBranch")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsTimelineMissing")
                        .HasColumnType("bit");

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.HasIndex("StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.HasIndex("DefinitionName", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.HasIndex("DefinitionNumber", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch" });

                    b.HasIndex("ModelBuildId", "Attempt")
                        .IsUnique();

                    b.HasIndex("NameKey", "Attempt")
                        .IsUnique();

                    b.ToTable("ModelBuildAttempts");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AzureOrganization")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AzureProject")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DefinitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DefinitionNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AzureOrganization", "AzureProject", "DefinitionNumber")
                        .IsUnique();

                    b.ToTable("ModelBuildDefinitions");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelGitHubIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Repository")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("Number", "Organization", "Repository");

                    b.HasIndex("Organization", "Repository", "Number", "ModelBuildId")
                        .IsUnique();

                    b.ToTable("ModelGitHubIssues");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelHelixLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HelixLogKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsContentTooLarge")
                        .HasColumnType("bit");

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LogUri")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTestRunId")
                        .HasColumnType("int");

                    b.Property<string>("WorkItemName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("LogUri")
                        .IsUnique();

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("ModelTestRunId");

                    b.ToTable("ModelHelixLogs");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelMigration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MigrationKind")
                        .HasColumnType("int");

                    b.Property<int?>("NewId")
                        .HasColumnType("int");

                    b.Property<int>("OldId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MigrationKind", "OldId")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Include", new[] { "NewId" });

                    b.ToTable("ModelMigrations");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<int>("OsxJobFailedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.ToTable("ModelOsxDeprovisionRetry");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<int>("BuildKind")
                        .HasColumnType("int");

                    b.Property<int>("BuildResult")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DefinitionNumber")
                        .HasColumnType("int");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubTargetBranch")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HelixConsoleUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixCoreDumpUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixRunClientUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixTestResultsUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHelixTestResult")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHelixWorkItem")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubResult")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubResultContainer")
                        .HasColumnType("bit");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTestRunId")
                        .HasColumnType("int");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestRunName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.HasIndex("ModelTestRunId")
                        .HasAnnotation("SqlServer:Include", new[] { "TestFullName", "TestRunName", "IsHelixTestResult" });

                    b.HasIndex("StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "TestFullName", "TestRunName", "IsHelixTestResult" });

                    b.HasIndex("DefinitionName", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "TestFullName", "TestRunName", "IsHelixTestResult" });

                    b.HasIndex("DefinitionNumber", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "TestFullName", "TestRunName", "IsHelixTestResult" });

                    b.HasIndex("ModelBuildId", "Attempt")
                        .HasAnnotation("SqlServer:Include", new[] { "TestFullName", "TestRunName", "IsHelixTestResult" });

                    b.ToTable("ModelTestResults");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AreHelixLogsComplete")
                        .HasColumnType("bit");

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TestRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelBuildId", "TestRunId")
                        .IsUnique();

                    b.ToTable("ModelTestRuns");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTimelineIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<int>("BuildKind")
                        .HasColumnType("int");

                    b.Property<int>("BuildResult")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DefinitionNumber")
                        .HasColumnType("int");

                    b.Property<string>("GitHubTargetBranch")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IssueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("ModelBuildId")
                        .HasColumnType("int");

                    b.Property<string>("RecordId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RecordName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.HasIndex("ModelBuildId")
                        .HasAnnotation("SqlServer:Include", new[] { "JobName", "TaskName", "RecordName", "IssueType", "Attempt", "Message" });

                    b.HasIndex("StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "IssueType", "JobName", "TaskName", "RecordName" });

                    b.HasIndex("DefinitionName", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "IssueType", "JobName", "TaskName", "RecordName" });

                    b.HasIndex("DefinitionNumber", "StartTime")
                        .HasAnnotation("SqlServer:Include", new[] { "BuildResult", "BuildKind", "GitHubTargetBranch", "IssueType", "JobName", "TaskName", "RecordName" });

                    b.HasIndex("ModelBuildId", "Attempt");

                    b.ToTable("ModelTimelineIssues");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GitHubIssueNumber")
                        .HasColumnType("int");

                    b.Property<string>("GitHubOrganization")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GitHubRepository")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("IssueTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("SearchQuery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.HasIndex("IsActive", "Id")
                        .IsUnique();

                    b.ToTable("ModelTrackingIssues");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HelixLogKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixLogUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelTestResultId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelTimelineIssueId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTrackingIssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelTestResultId");

                    b.HasIndex("ModelTimelineIssueId");

                    b.HasIndex("ModelTrackingIssueId");

                    b.ToTable("ModelTrackingIssueMatches");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTrackingIssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("IsPresent", "ModelTrackingIssueId");

                    b.HasIndex("ModelTrackingIssueId", "ModelBuildAttemptId")
                        .IsUnique();

                    b.ToTable("ModelTrackingIssueResults");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuild", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildAttempt", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelBuildAttempts")
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelGitHubIssue", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelGitHubIssues")
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelHelixLog", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany()
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelHelixLogs")
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTestRun", "ModelTestRun")
                        .WithMany()
                        .HasForeignKey("ModelTestRunId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestResult", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany()
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelTestResults")
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTestRun", "ModelTestRun")
                        .WithMany()
                        .HasForeignKey("ModelTestRunId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestRun", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany()
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTimelineIssue", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany()
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelTimelineIssues")
                        .HasForeignKey("ModelBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssue", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueMatch", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany("ModelTrackingIssueMatches")
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTestResult", "ModelTestResult")
                        .WithMany()
                        .HasForeignKey("ModelTestResultId");

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTimelineIssue", "ModelTimelineIssue")
                        .WithMany()
                        .HasForeignKey("ModelTimelineIssueId");

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTrackingIssue", "ModelTrackingIssue")
                        .WithMany("ModelTrackingIssueMatches")
                        .HasForeignKey("ModelTrackingIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueResult", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany("ModelTrackingIssueResults")
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTrackingIssue", "ModelTrackingIssue")
                        .WithMany()
                        .HasForeignKey("ModelTrackingIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
