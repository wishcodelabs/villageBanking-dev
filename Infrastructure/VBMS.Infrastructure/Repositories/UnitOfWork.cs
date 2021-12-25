



using VBMS.Domain.SeedWork.Contracts;

namespace VBMS.Infrastructure.Repositories;
#nullable disable
public class UnitOfWork<TKey> : IUnitOfWork<TKey>
{

    bool disposed;
    readonly SystemDbContext database;
    Hashtable repositories;
    public UnitOfWork(SystemDbContext _database)
    {
        database = _database ?? throw new ArgumentNullException(nameof(database));
    }
    public async Task<int> Commit(CancellationToken cancellationToken)
    {
        return await database.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IRepositoryAsync<T, TKey> Repository<T>() where T : class, IEntity<TKey>
    {
        if (repositories == null)
            repositories = new Hashtable();
        var type = typeof(T).Name;
        if (!repositories.ContainsKey(type))
        {
            var repoType = typeof(RepositoryAsync<,>);
            var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T), typeof(TKey)), database);
            repositories.Add(type, repoInstance);
        }
        return (IRepositoryAsync<T, TKey>)repositories[type];
    }

    public Task RollBack()
    {
        database.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed resources
                database.Dispose();
            }
        }
        //disposed unmanaged resources
        disposed = true;
    }
}
