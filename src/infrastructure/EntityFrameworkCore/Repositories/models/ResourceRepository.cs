using domain.interfaces;
using domain.models.resource;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class ResourceRepository(EfcDbContext context) : IRepository<Resource>
{
    /// <summary>
    /// Gets all resources from the database.
    /// </summary>
    /// <returns>Returns the complete list of resources in the database.</returns>
    public async Task<IEnumerable<Resource>> GetAllAsync()
    {
        // * Get all resources from the database.
        return await context.Resources.ToListAsync();
    }

    /// <summary>
    /// Gets a specific resource by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the resource with the specified uid or null.</returns>
    public async Task<Resource?> GetByIdAsync(Guid uid)
    {
        // * Find a resource by their uid.
        return await context.Resources.FirstOrDefaultAsync(resource => resource.Uid == uid);
    }

    /// <summary>
    /// Adds a resource to the database.
    /// </summary>
    /// <param name="toAdd">Resource to be added.</param>
    public async Task AddAsync(Resource toAdd)
    {
        // * Add the resource to the database.
        await context.Resources.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a resource in the database.
    /// </summary>
    /// <param name="toUpdate">Resource to be updated.</param>
    public void Update(Resource toUpdate)
    {
        // * Update the resource in the database.
        context.Resources.Update(toUpdate);
    }

    /// <summary>
    /// Removes a resource from the database.
    /// </summary>
    /// <param name="toRemove">Resource to be removed.</param>
    public void Remove(Resource toRemove)
    {
        // * Remove the resource from the database.
        context.Resources.Remove(toRemove);
    }
}