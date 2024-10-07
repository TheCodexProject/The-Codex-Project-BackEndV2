using domain.models.resource;
using domain.models.board;
using domain.models.board.values;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.organisation;
using domain.models.project;
using domain.models.user;
using domain.models.workitem;
using domain.models.workspace;
using EntityFrameworkCore.Configs;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore;

public class EfcDbContext : DbContext
{
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkItem> WorkItems { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Milestone> Milestones { get; set; }
    public DbSet<Iteration> Iterations { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<FilterCriteria> FilterCriteria { get; set; }
    public DbSet<OrderByCriteria> OrderByCriteria { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Db.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply the Entity specific configurations.
        modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        modelBuilder.ApplyConfiguration(new OrganisationConfiguration());
        modelBuilder.ApplyConfiguration(new OrderByCriteriaConfiguration());
        modelBuilder.ApplyConfiguration(new FilterCriteriaConfiguration());
        modelBuilder.ApplyConfiguration(new MilestoneConfiguration());
        modelBuilder.ApplyConfiguration(new IterationConfiguration());
        modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}