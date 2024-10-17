using domain.interfaces;
using domain.models.project;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class ProjectRepository(EfcDbContext context) : IRepository<Project>
{
    /// <summary>
    /// Gets all projects from the database.
    /// </summary>
    /// <returns>Returns the complete list of projects in the database.</returns>
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        // * Get all projects from the database.
        return await context.Projects.ToListAsync();
    }

    /// <summary>
    /// Gets a specific project by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the project with the specified uid or null.</returns>
    public async Task<Project?> GetByIdAsync(Guid uid)
    {
        // * Find a project by their uid.
        return await context.Projects.FirstOrDefaultAsync(project => project.Uid == uid);
    }


    /// <summary>
    /// Adds a project to the database.
    /// </summary>
    /// <param name="toAdd">Project to be added.</param>
    public async Task AddAsync(Project toAdd)
    {
        // * Add a project to the database.
        await context.Projects.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a project in the database.
    /// </summary>
    /// <param name="toUpdate">Project to be updated.</param>
    public void Update(Project toUpdate)
    {
        // * Update a project in the database.
        context.Projects.Update(toUpdate);
    }

    /// <summary>
    /// Removes a project from the database.
    /// </summary>
    /// <param name="toRemove">Project to be removed.</param>
    public void Remove(Project toRemove)
    {
        // * Remove a project from the database.
        context.Projects.Remove(toRemove);
    }
}