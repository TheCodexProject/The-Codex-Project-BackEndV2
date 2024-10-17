using domain.interfaces;
using domain.models.workspace;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class WorkspaceRepository(EfcDbContext context) : IRepository<Workspace>
{
    /// <summary>
    /// Gets a list of all workspaces in the database.
    /// </summary>
    /// <returns>Return the complete list of workspaces in the database</returns>
    public async Task<IEnumerable<Workspace>> GetAllAsync()
    {
        // * Get all workspaces from the database.
        return await context.Workspaces.ToListAsync();
    }

    /// <summary>
    /// Gets a specific workspace by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the specified workspace or null.</returns>
    public async Task<Workspace?> GetByIdAsync(Guid uid)
    {
        // * Find a workspace by their uid.
        return await context.Workspaces.FirstOrDefaultAsync(workspace => workspace.Uid == uid);
    }

    /// <summary>
    /// Adds a workspace to the database.
    /// </summary>
    /// <param name="toAdd">Workspace to be added.</param>
    /// <returns></returns>
    public async Task AddAsync(Workspace toAdd)
    {
        // * Add the workspace to the database.
        await context.Workspaces.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a workspace in the database.
    /// </summary>
    /// <param name="toUpdate">Workspace to be updated.</param>
    public void Update(Workspace toUpdate)
    {
        // * Update the workspace in the database.
        context.Workspaces.Update(toUpdate);
    }

    /// <summary>
    /// Removes a workspace from the database.
    /// </summary>
    /// <param name="toRemove">Workspace to be removed.</param>
    public void Remove(Workspace toRemove)
    {
        // * Remove the workspace from the database.
        context.Workspaces.Remove(toRemove);
    }
}