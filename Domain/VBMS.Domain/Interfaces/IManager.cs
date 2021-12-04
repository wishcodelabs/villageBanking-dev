namespace VBMS.Domain.Interfaces;

public interface IManager<T, TKey> where T : class, IEntity<TKey>
{

}
