using JSdotNet.Domain.Abstractions.Events;

namespace JSdotNet.Domain.Abstractions;

public abstract class AggregateRoot(Guid id) : AggregateRoot<Guid>(id);


public abstract class AggregateRoot<TKey>(TKey id) : Entity<TKey>(id), IHasDomainEvents
{
    protected DomainEventWrapper DomainEvents { get; } = new();

    IReadOnlyList<IDomainEvent> IHasDomainEvents.DomainEvents => DomainEvents.Items;
    void IHasDomainEvents.Clear() => DomainEvents.Clear();
}