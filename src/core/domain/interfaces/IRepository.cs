using System.Linq.Expressions;

namespace domain.interfaces;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// A method to get all entities from the repository.
    /// </summary>
    /// <returns>All objects of type T stored in database.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// A method to find entities based on a predicate.
    /// </summary>
    /// <param name="predicate">Filter to follow.</param>
    /// <returns>An object of type T</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// A method to get an entity by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An object of type T</returns>
    Task<T> GetByIdAsync(int id);

    /// <summary>
    /// A method to add an entity to the repository.
    /// </summary>
    /// <param name="entity">An object of type T</param>
    /// <returns></returns>
    Task AddAsync(T entity);

    /// <summary>
    /// A method to update an entity in the repository.
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// A method to delete an entity from the repository.
    /// </summary>
    /// <param name="entity">An object of type T</param>
    void Delete(T entity);
}
