namespace VBMS.Domain.Interfaces;

public interface IRepositoryAsync<T, in TKey> where T : class, IEntity<TKey>
{
    IQueryable<T> Entities { get; }
    Task<T> GetAsync(TKey id);

    Task<List<T>> GetAllAsync();

    Task<bool> DeleteAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> AddAsync(T entity);
}
