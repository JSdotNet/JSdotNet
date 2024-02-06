using JSdotNet.Application._.Messaging;
using JSdotNet.Domain.Abstractions;

using MediatR;

using SolutionTemplate.Domain;

namespace JSdotNet.Application.@_.Behaviors;

internal sealed class UnitOfWorkPipelineBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // This behavior should only be applied to commands
        var isCommand = typeof(TRequest).GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommand<>));
        if (!isCommand)
            return await next();


        //using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var response = await next();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        //transaction.Complete();

        return response;
    }
}