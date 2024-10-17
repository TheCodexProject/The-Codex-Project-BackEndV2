using domain.interfaces;
using domain.models.workitem;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class WorkItemRepository(EfcDbContext context) : IRepository<WorkItem>
{
    /// <summary>
    /// Gets a list of all work items in the database.
    /// </summary>
    /// <returns>Returns the complete list of work items in the database.</returns>
    public async Task<IEnumerable<WorkItem>> GetAllAsync()
    {
        // * Get all work items from the database.
        return await context.WorkItems.ToListAsync();
    }

    /// <summary>
    /// Gets a specific work item by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the specified workspace or null.</returns>
    public async Task<WorkItem?> GetByIdAsync(Guid uid)
    {
        // * Find a work item by their uid.
        return await context.WorkItems.FirstOrDefaultAsync(workitem => workitem.Uid == uid);
    }

    /// <summary>
    /// Adds a work item to the database.
    /// </summary>
    /// <param name="toAdd">Work item to be added.</param>
    public async Task AddAsync(WorkItem toAdd)
    {
        // * Add the work item to the database.
        await context.WorkItems.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a work item in the database.
    /// </summary>
    /// <param name="toUpdate">Work item to be updated.</param>
    public void Update(WorkItem toUpdate)
    {
        // * Update the work item in the database.
        context.WorkItems.Update(toUpdate);
    }

    /// <summary>
    /// Removes a work item from the database.
    /// </summary>
    /// <param name="toRemove">Work item to be removed.</param>
    public void Remove(WorkItem toRemove)
    {
        // * Remove the work item from the database.
        context.WorkItems.Remove(toRemove);
    }
}