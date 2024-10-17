using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.organization;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workitem;
using domain.models.workspace;

namespace domain.interfaces;

/// <summary>
/// Unit of Work interface
/// </summary>
public interface IUnitOfWork
{
    // ! Must have access to all repositories
    IRepository<Workspace> Workspaces { get; }
    IRepository<WorkItem> WorkItems { get; }
    IRepository<User> Users { get; }
    IRepository<Resource> Resources { get; }
    IRepository<Project> Projects { get; }
    IRepository<Organization> Organizations { get; }
    IRepository<Milestone> Milestones { get; }
    IRepository<Iteration> Iterations { get; }
    IRepository<Board> Boards { get; }

    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}