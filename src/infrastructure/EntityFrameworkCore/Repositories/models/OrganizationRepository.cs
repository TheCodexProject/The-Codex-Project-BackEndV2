using domain.interfaces;
using domain.models.organization;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class OrganizationRepository(EfcDbContext context) : IRepository<Organization>
{
    /// <summary>
    /// Gets all organizations from the database.
    /// </summary>
    /// <returns>Returns the complete list of organizations in the database.</returns>
    public async Task<IEnumerable<Organization>> GetAllAsync()
    {
        // * Get all organizations from the database.
        return await context.Organisations.ToListAsync();
    }
    /// <summary>
    /// Gets a specific organization by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the organization with the specified uid or null.</returns>
    public async Task<Organization?> GetByIdAsync(Guid uid)
    {
        // * Find an organization by their uid.
        return await context.Organisations.FirstOrDefaultAsync(organization => organization.Uid == uid);
    }

    /// <summary>
    /// Adds an organization to the database.
    /// </summary>
    /// <param name="toAdd"></param>
    public async Task AddAsync(Organization toAdd)
    {
        // * Add an organization to the database.
        await context.Organisations.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates an organization in the database.
    /// </summary>
    /// <param name="toUpdate"></param>
    public void Update(Organization toUpdate)
    {
        // * Update an organization in the database.
        context.Organisations.Update(toUpdate);
    }

    /// <summary>
    /// Removes an organization from the database.
    /// </summary>
    /// <param name="toRemove"></param>
    public void Remove(Organization toRemove)
    {
        // * Remove an organization from the database.
        context.Organisations.Remove(toRemove);
    }
}