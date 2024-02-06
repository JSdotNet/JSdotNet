using JSdotNet.Domain.Abstractions.Model;

namespace JSdotNet.Domain.Abstractions;

public abstract class Entity(Guid id) : IHasId
{
    public Guid Id { get; } = id;
}


public abstract class Entity<TKey>(TKey key) : IHasId<TKey>
   // where TKey : class
{
    public TKey Id { get; } = key;
}