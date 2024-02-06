using MediatR;

namespace JSdotNet.Domain.Abstractions.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
}