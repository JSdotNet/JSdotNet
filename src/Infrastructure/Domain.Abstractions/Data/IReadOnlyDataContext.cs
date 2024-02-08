namespace JSdotNet.Domain.Abstractions.Data;

public interface IReadOnlyDataContext
{
    IQueryable<TEntity> Query<TEntity>() where TEntity : class;

    IAsyncEnumerable<TEntity> GetAsyncEnumerable<TEntity>() where TEntity : class;
}