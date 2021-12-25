namespace VBMS.Domain.SeedWork.Interfaces;

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
public interface IEntity
{

}
