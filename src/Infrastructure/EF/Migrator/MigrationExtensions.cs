using Microsoft.Extensions.DependencyInjection;

namespace JSdotNet.Infrastructure.EF.Migrator;

public static class MigrationExtensions
{
    public static async Task ApplyMigrations(this IServiceProvider serviceProvider)
    {
        var applyMigrations = serviceProvider.GetService<IDatabaseMigrator>();
        if (applyMigrations != null)
            await applyMigrations.Execute();
    }
}