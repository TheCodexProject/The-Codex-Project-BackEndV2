﻿// <auto-generated />
using System;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCore.Migrations
{
    [DbContext(typeof(EfcDbContext))]
    partial class EfcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("OrganizationOwners", b =>
                {
                    b.Property<Guid>("OrganizationUid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserUid")
                        .HasColumnType("TEXT");

                    b.HasKey("OrganizationUid", "UserUid");

                    b.HasIndex("UserUid");

                    b.ToTable("OrganizationOwners");
                });

            modelBuilder.Entity("ResourceWorkItem", b =>
                {
                    b.Property<Guid>("ResourcesUid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkItemUid")
                        .HasColumnType("TEXT");

                    b.HasKey("ResourcesUid", "WorkItemUid");

                    b.HasIndex("WorkItemUid");

                    b.ToTable("WorkItemResources", (string)null);
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.Property<Guid>("ContactsUid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkspaceUid")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactsUid", "WorkspaceUid");

                    b.HasIndex("WorkspaceUid");

                    b.ToTable("WorkspaceContacts", (string)null);
                });

            modelBuilder.Entity("WorkItemWorkItem", b =>
                {
                    b.Property<Guid>("DependenciesUid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkItemUid")
                        .HasColumnType("TEXT");

                    b.HasKey("DependenciesUid", "WorkItemUid");

                    b.HasIndex("WorkItemUid");

                    b.ToTable("WorkItemDependencies", (string)null);
                });

            modelBuilder.Entity("domain.models.board.Board", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectUid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("ProjectUid");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("domain.models.board.values.FilterCriteria", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BoardUid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("BoardUid");

                    b.ToTable("FilterCriteria");
                });

            modelBuilder.Entity("domain.models.board.values.OrderByCriteria", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BoardUid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAscending")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("BoardUid");

                    b.ToTable("OrderByCriteria");
                });

            modelBuilder.Entity("domain.models.iteration.Iteration", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectUid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkItems")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("ProjectUid");

                    b.ToTable("Iterations");
                });

            modelBuilder.Entity("domain.models.milestone.Milestone", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectUid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkItems")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("ProjectUid");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("domain.models.organization.Organization", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("domain.models.project.Project", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Framework")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkspaceUid")
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("WorkspaceUid");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("domain.models.resource.Resource", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganizationUid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkspaceUid")
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.HasIndex("OrganizationUid");

                    b.HasIndex("WorkspaceUid");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("domain.models.user.User", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("domain.models.workitem.WorkItem", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AssignedToId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProjectUid")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("INTEGER");

                    b.HasKey("Uid");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectUid");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("domain.models.workspace.Workspace", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Uid");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("OrganizationOwners", b =>
                {
                    b.HasOne("domain.models.organization.Organization", null)
                        .WithMany()
                        .HasForeignKey("OrganizationUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.user.User", null)
                        .WithMany()
                        .HasForeignKey("UserUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResourceWorkItem", b =>
                {
                    b.HasOne("domain.models.resource.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.workitem.WorkItem", null)
                        .WithMany()
                        .HasForeignKey("WorkItemUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.HasOne("domain.models.user.User", null)
                        .WithMany()
                        .HasForeignKey("ContactsUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.workspace.Workspace", null)
                        .WithMany()
                        .HasForeignKey("WorkspaceUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkItemWorkItem", b =>
                {
                    b.HasOne("domain.models.workitem.WorkItem", null)
                        .WithMany()
                        .HasForeignKey("DependenciesUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.workitem.WorkItem", null)
                        .WithMany()
                        .HasForeignKey("WorkItemUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.board.Board", b =>
                {
                    b.HasOne("domain.models.project.Project", null)
                        .WithMany("Boards")
                        .HasForeignKey("ProjectUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.board.values.FilterCriteria", b =>
                {
                    b.HasOne("domain.models.board.Board", null)
                        .WithMany("FilterCriterias")
                        .HasForeignKey("BoardUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.board.values.OrderByCriteria", b =>
                {
                    b.HasOne("domain.models.board.Board", null)
                        .WithMany("OrderByCriterias")
                        .HasForeignKey("BoardUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.iteration.Iteration", b =>
                {
                    b.HasOne("domain.models.project.Project", null)
                        .WithMany("Iterations")
                        .HasForeignKey("ProjectUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.milestone.Milestone", b =>
                {
                    b.HasOne("domain.models.project.Project", null)
                        .WithMany("Milestones")
                        .HasForeignKey("ProjectUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.project.Project", b =>
                {
                    b.HasOne("domain.models.workspace.Workspace", "Workspace")
                        .WithMany("Projects")
                        .HasForeignKey("WorkspaceUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("domain.models.resource.Resource", b =>
                {
                    b.HasOne("domain.models.organization.Organization", null)
                        .WithMany("Resources")
                        .HasForeignKey("OrganizationUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.workspace.Workspace", null)
                        .WithMany("Resources")
                        .HasForeignKey("WorkspaceUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.models.workitem.WorkItem", b =>
                {
                    b.HasOne("domain.models.user.User", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("domain.models.workitem.WorkItem", "Parent")
                        .WithMany("SubItems")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("domain.models.project.Project", null)
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("domain.models.board.Board", b =>
                {
                    b.Navigation("FilterCriterias");

                    b.Navigation("OrderByCriterias");
                });

            modelBuilder.Entity("domain.models.organization.Organization", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("domain.models.project.Project", b =>
                {
                    b.Navigation("Boards");

                    b.Navigation("Iterations");

                    b.Navigation("Milestones");

                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("domain.models.workitem.WorkItem", b =>
                {
                    b.Navigation("SubItems");
                });

            modelBuilder.Entity("domain.models.workspace.Workspace", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
