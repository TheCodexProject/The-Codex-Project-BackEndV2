using domain.interfaces;
using domain.models.user;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class UserRepository(EfcDbContext context) : IRepository<User>
{
    /// <summary>
    /// Gets a list of all users in the database.
    /// </summary>
    /// <returns>Returns the complete list of users in the database.</returns>
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        // * Get all users from the database.
        return await context.Users.ToListAsync();
    }

    /// <summary>
    /// Gets a specific user by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the user with the specified uid or null. </returns>
    public async Task<User?> GetByIdAsync(Guid uid)
    {
        // * Find a user by their uid.
        return await context.Users.FirstOrDefaultAsync(user => user.Uid == uid);
    }

    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="toAdd">User to be added.</param>
    public async Task AddAsync(User toAdd)
    {
        // * Add the user to the database.
        await context.Users.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a user in the database.
    /// </summary>
    /// <param name="toUpdate">User to be updated.</param>
    public void Update(User toUpdate)
    {
        // * Update the user in the database.
        context.Users.Update(toUpdate);
    }

    /// <summary>
    /// Removes a user from the database.
    /// </summary>
    /// <param name="toRemove">User to be removed.</param>
    public void Remove(User toRemove)
    {
        // * Remove the user from the database.
        context.Users.Remove(toRemove);
    }
}