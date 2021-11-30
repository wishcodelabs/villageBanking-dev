
namespace VBMS.Domain.Interfaces;

public interface IUnitOfWork<TKey>:IDisposable
{
    IRepositoryAsync<T, TKey> Repository<T>() where T : Entity<TKey>;

    Task<int> Commit(CancellationToken cancellationToken);

    Task RollBack();
}
