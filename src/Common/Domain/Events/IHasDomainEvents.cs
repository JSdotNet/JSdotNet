namespace JSdotNet.Common.Domain.Events;

public interface IHasDomainEvents
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    void Clear();
}
