
namespace VBMS.Domain.Interfaces;

public interface IRepositoryAsync<T, in TKey> where T : class, IEntity<TKey>
{
    IQueryable<T> Entities { get; }
    Task<T> GetAsync(TKey id);

    Task<List<T>> GetAllAsync();    

    Task DeleteAsync(T entity);

    Task UpdateAsync(T entity); 

    Task<T> AddAsync(T entity);
}
