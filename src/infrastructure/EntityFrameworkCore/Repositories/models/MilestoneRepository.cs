using domain.interfaces;
using domain.models.milestone;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class MilestoneRepository(EfcDbContext context) : IRepository<Milestone>
{
    /// <summary>
    /// Gets all milestones from the database.
    /// </summary>
    /// <returns>Returns the complete list of milestones in the database.</returns>
    public async Task<IEnumerable<Milestone>> GetAllAsync()
    {
        // * Get all milestones from the database.
        return await context.Milestones.ToListAsync();
    }

    /// <summary>
    /// Gets a specific milestone by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the milestone with the specified uid or null.</returns>
    public async Task<Milestone?> GetByIdAsync(Guid uid)
    {
        // * Find a milestone by their uid.
        return await context.Milestones.FirstOrDefaultAsync(milestone => milestone.Uid == uid);
    }

    /// <summary>
    /// Adds a milestone to the database.
    /// </summary>
    /// <param name="toAdd"></param>
    public async Task AddAsync(Milestone toAdd)
    {
        // * Add a milestone to the database.
        await context.Milestones.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a milestone in the database.
    /// </summary>
    /// <param name="toUpdate"></param>
    public void Update(Milestone toUpdate)
    {
        // * Update a milestone in the database.
        context.Milestones.Update(toUpdate);
    }

    /// <summary>
    /// Removes a milestone from the database.
    /// </summary>
    /// <param name="toRemove"></param>
    public void Remove(Milestone toRemove)
    {
        // * Remove a milestone from the database.
        context.Milestones.Remove(toRemove);
    }
}