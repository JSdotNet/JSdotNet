namespace JSdotNet.Domain.Abstractions.Model;

public interface IHasId : IHasId<Guid>
{
}


public interface IHasId<out TId>
{
    TId Id { get; }
}