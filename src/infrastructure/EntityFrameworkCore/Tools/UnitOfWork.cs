using domain.interfaces;
using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.organization;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workitem;
using domain.models.workspace;

namespace EntityFrameworkCore.tools;

/// <summary>
/// The Unit of work is used to manage all changes to the database and then save them all at once.
/// </summary>
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly EfcDbContext _context;

    #region Repostiories

    public IRepository<Workspace> Workspaces { get; }
    public IRepository<WorkItem> WorkItems { get; }
    public IRepository<User> Users { get; }
    public IRepository<Resource> Resources { get; }
    public IRepository<Project> Projects { get; }
    public IRepository<Organization> Organizations { get; }
    public IRepository<Milestone> Milestones { get; }
    public IRepository<Iteration> Iterations { get; }
    public IRepository<Board> Boards { get; }

    #endregion

    public UnitOfWork(
        EfcDbContext context,
        IRepository<Workspace> workspaces,
        IRepository<WorkItem> workItems,
        IRepository<User> users,
        IRepository<Resource> resources,
        IRepository<Project> projects,
        IRepository<Organization> organizations,
        IRepository<Milestone> milestones,
        IRepository<Iteration> iterations,
        IRepository<Board> boards)
    {
        _context = context;
        Workspaces = workspaces;
        WorkItems = workItems;
        Users = users;
        Resources = resources;
        Projects = projects;
        Organizations = organizations;
        Milestones = milestones;
        Iterations = iterations;
        Boards = boards;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
