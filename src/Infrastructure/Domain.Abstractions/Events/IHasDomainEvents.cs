namespace JSdotNet.Domain.Abstractions.Events;

public interface IHasDomainEvents
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    void Clear();
}
