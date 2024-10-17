using domain.interfaces;
using domain.models.iteration;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class IterationRepository(EfcDbContext context) : IRepository<Iteration>
{
    /// <summary>
    /// Gets all iterations from the database.
    /// </summary>
    /// <returns>Returns the complete list of iterations in the database.</returns>
    public async Task<IEnumerable<Iteration>> GetAllAsync()
    {
        // * Get all projects from the database.
        return await context.Iterations.ToListAsync();
    }

    /// <summary>
    /// Gets a specific iteration by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the iteration with the specified uid or null.</returns>
    public async Task<Iteration?> GetByIdAsync(Guid uid)
    {
        // * Find a project by their uid.
        return await context.Iterations.FirstOrDefaultAsync(iteration => iteration.Uid == uid);
    }

    /// <summary>
    /// Adds an iteration to the database.
    /// </summary>
    /// <param name="toAdd"></param>
    public async Task AddAsync(Iteration toAdd)
    {
        // * Add a project to the database.
        await context.Iterations.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates an iteration in the database.
    /// </summary>
    /// <param name="toUpdate"></param>
    public void Update(Iteration toUpdate)
    {
        // * Update a project in the database.
        context.Iterations.Update(toUpdate);
    }

    /// <summary>
    /// Removes an iteration from the database.
    /// </summary>
    /// <param name="toRemove"></param>
    public void Remove(Iteration toRemove)
    {
        // * Remove a project from the database.
        context.Iterations.Remove(toRemove);
    }
}