using VBMS.Domain.SeedWork.Interfaces;

namespace VBMS.Domain.Interfaces;

public interface IService<T, TKey> where T : class, IEntity<TKey>
{

}
public interface IService
{

}

