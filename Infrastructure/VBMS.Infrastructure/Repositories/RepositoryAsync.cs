
namespace VBMS.Infrastructure.Repositories;

public class RepositoryAsync<T, TKey> : IRepositoryAsync<T, TKey> where T : class, IEntity<TKey>
{
#nullable disable
    readonly SystemDbContext database;
    public RepositoryAsync(SystemDbContext _database)
    {
        database = _database;
    }
    public IQueryable<T> Entities => database.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await database.Set<T>().AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            WriteLine(e.Message + e.StackTrace);
            return false;
        }
    }

    public Task<bool> DeleteAsync(T entity)
    {
        try
        {
            database.Set<T>().Remove(entity);
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            WriteLine(e.Message + e.StackTrace);
            return Task.FromResult(false);
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await database.Set<T>()
                             .ToListAsync();
    }

    public async Task<T> GetAsync(TKey Id)
    {

        return await database.Set<T>().FindAsync(Id);

    }

    public Task<bool> UpdateAsync(T entity)
    {
        try
        {
            database.Set<T>().Update(entity);
            return Task.FromResult(true);
        }
        catch (Exception e)
        {

            WriteLine(e.Message + e.StackTrace);
            return Task.FromResult(false);
        }
    }
}
