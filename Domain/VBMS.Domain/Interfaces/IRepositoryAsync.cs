namespace VBMS.Domain.Interfaces;

public interface IRepositoryAsync<T, in TKey> where T : class, IEntity<TKey>
{
    IQueryable<T> Entities(bool includeNavigation = true);
    Task<T> GetAsync(TKey id);

    Task<List<T>> GetAllAsync();

    Task<bool> DeleteAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> AddAsync(T entity);
}
