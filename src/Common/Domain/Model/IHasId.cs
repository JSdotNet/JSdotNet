namespace JSdotNet.Common.Domain.Model;

public interface IHasId : IHasId<Guid>
{
}


public interface IHasId<out TId>
{
    TId Id { get; }
}