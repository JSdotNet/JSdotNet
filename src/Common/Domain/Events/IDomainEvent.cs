using MediatR;

namespace JSdotNet.Common.Domain.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
}