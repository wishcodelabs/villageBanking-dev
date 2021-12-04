namespace VBMS.Infrastructure.Managers;

public abstract class ManagerBase<T, TKey> : IManager<T, TKey> where T : Entity<TKey>
{
    private IUnitOfWork<TKey> UnitOfWork { get; init; }


    public ManagerBase(IUnitOfWork<TKey> unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected IRepositoryAsync<T, TKey> Repository { get => UnitOfWork.Repository<T>(); }

    public async Task<int> AddAsync(T entity)
    {
        var result = await UnitOfWork.Repository<T>().AddAsync(entity);
        return result ? await UnitOfWork.Commit(new CancellationToken()) : 1;

    }
    public async Task<int> UpdateAsync(T entity)
    {
        var result = await UnitOfWork.Repository<T>().UpdateAsync(entity);
        return result ? await UnitOfWork.Commit(new CancellationToken()) : 1;
    }
    public async Task<int> DeleteAsync(T entity)
    {
        var result = await UnitOfWork.Repository<T>().DeleteAsync(entity);
        return result ? await UnitOfWork.Commit(new CancellationToken()) : 1;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await UnitOfWork.Repository<T>().GetAllAsync();
    }
    public async Task<T> GetByIdAsync(TKey id)
    {
        return await UnitOfWork.Repository<T>().GetAsync(id);
    }

}
