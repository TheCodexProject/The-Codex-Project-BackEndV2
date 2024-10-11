using domain.models.resource;
using domain.models.board;
﻿using domain.models.board;
using domain.models.board.values;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.organization;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workitem;
using domain.models.workspace;
using EntityFrameworkCore.configs;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore;

public class EfcDbContext : DbContext
{
    public DbSet<Workspace> Workspaces { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<WorkItem> WorkItems { get; init; }
    public DbSet<Resource> Resources { get; init; }
    public DbSet<Project> Projects { get; init; }
    public DbSet<Organization> Organisations { get; init; }
    public DbSet<Milestone> Milestones { get; init; }
    public DbSet<Iteration> Iterations { get; init; }
    public DbSet<Board> Boards { get; init; }
    public DbSet<FilterCriteria> FilterCriteria { get; init; }
    public DbSet<OrderByCriteria> OrderByCriteria { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=localdb.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply the Entity specific configurations.
        modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        modelBuilder.ApplyConfiguration(new OrderByCriteriaConfiguration());
        modelBuilder.ApplyConfiguration(new FilterCriteriaConfiguration());
        modelBuilder.ApplyConfiguration(new MilestoneConfiguration());
        modelBuilder.ApplyConfiguration(new IterationConfiguration());
        modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}