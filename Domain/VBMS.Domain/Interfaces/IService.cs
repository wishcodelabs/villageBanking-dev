

namespace VBMS.Domain.Interfaces;

public interface IService<T, TKey> : IService where T : class, IEntity<TKey>
{

}
public interface IIdentityService : IService
{

}
public interface IService
{

}

