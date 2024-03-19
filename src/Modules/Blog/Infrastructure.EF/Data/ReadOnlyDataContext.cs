using JSdotNet.Common.Domain.Data;

using Microsoft.EntityFrameworkCore;

namespace JSdotNet.Blog.Infrastructure.EF.Data;

internal sealed class ReadOnlyDataContext(DataContext dbContext) : IReadOnlyDataContext
{
    // TODO Use readonly connectionString?

    public IQueryable<TEntity> Query<TEntity>() where TEntity : class
    {
        return dbContext.Set<TEntity>().AsNoTracking();
    }


    public IAsyncEnumerable<TEntity> GetAsyncEnumerable<TEntity>() where TEntity : class
    {
        return dbContext.Set<TEntity>().AsNoTracking().AsAsyncEnumerable();
    }
}
