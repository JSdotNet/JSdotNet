namespace JSdotNet.Blog.Infrastructure.EF.Migrator;

public interface IDatabaseMigrator
{
    Task Execute(CancellationToken cancellationToken = default);
}
