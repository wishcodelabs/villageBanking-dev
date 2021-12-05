namespace VBMS.Infrastructure.Services;

public abstract class ServiceBase<T, TKey> : IService<T, TKey> where T : Entity<TKey>
{
    private IUnitOfWork<TKey> unitOfWork;


    public ServiceBase(IUnitOfWork<TKey> _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    protected IRepositoryAsync<T, TKey> Repository { get => unitOfWork.Repository<T>(); }

    public async Task<bool> AddAsync(T entity)
    {
        var result = await unitOfWork.Repository<T>().AddAsync(entity);
        if (result)
        {
            await unitOfWork.Commit(new CancellationToken());
        }
        else
        {
            await unitOfWork.RollBack();
        }
        return result;

    }
    public async Task<bool> UpdateAsync(T entity)
    {
        var result = await unitOfWork.Repository<T>().UpdateAsync(entity);
        if (result)
        {
            await unitOfWork.Commit(new CancellationToken());
        }
        else
        {
            await unitOfWork.RollBack();
        }
        return result;
    }
    public async Task<bool> DeleteAsync(T entity)
    {
        var result = await unitOfWork.Repository<T>().DeleteAsync(entity);
        if (result)
        {
            await unitOfWork.Commit(new CancellationToken());
        }
        else
        {
            await unitOfWork.RollBack();
        }
        return result;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await unitOfWork.Repository<T>().GetAllAsync();
    }
    public async Task<T> GetByIdAsync(TKey id)
    {
        return await unitOfWork.Repository<T>().GetAsync(id);
    }

}
