using domain.interfaces;
using domain.models.board;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.repositories.models;

public class BoardRepository(EfcDbContext context) : IRepository<Board>
{
    /// <summary>
    /// Gets all boards from the database.
    /// </summary>
    /// <returns>Returns the complete list of boards in the database.</returns>
    public async Task<IEnumerable<Board>> GetAllAsync()
    {
        // * Get all projects from the database.
        return await context.Boards.ToListAsync();
    }

    /// <summary>
    /// Gets a specific board by their uid.
    /// </summary>
    /// <param name="uid">Uid to search for.</param>
    /// <returns>Returns either the board with the specified uid or null.</returns>
    public async Task<Board?> GetByIdAsync(Guid uid)
    {
        // * Find a project by their uid.
        return await context.Boards.FirstOrDefaultAsync(board => board.Uid == uid);
    }

    /// <summary>
    /// Adds a board to the database.
    /// </summary>
    /// <param name="toAdd"></param>
    public async Task AddAsync(Board toAdd)
    {
        // * Add a project to the database.
        await context.Boards.AddAsync(toAdd);
    }

    /// <summary>
    /// Updates a board in the database.
    /// </summary>
    /// <param name="toUpdate"></param>
    public void Update(Board toUpdate)
    {
        // * Update a project in the database.
        context.Boards.Update(toUpdate);
    }


    /// <summary>
    /// Removes a board from the database.
    /// </summary>
    /// <param name="toRemove"></param>
    public void Remove(Board toRemove)
    {
        // * Remove a project from the database.
        context.Boards.Remove(toRemove);
    }
}