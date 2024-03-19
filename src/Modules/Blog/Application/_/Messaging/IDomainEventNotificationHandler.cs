using JSdotNet.Common.Domain.Events;

using MediatR;

namespace JSdotNet.Application.@_.Messaging;


public interface IDomainEventNotificationHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;
