namespace VBMS.Domain.SeedWork.Contracts;

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
public interface IEntity
{

}
