using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;
using Sohan.User.Indexes;
using YesSql.Sql;

namespace Sohan.User;

public class Migrations(IRecipeMigrator recipeMigrator) : DataMigration
{
    private readonly IRecipeMigrator _recipeMigrator = recipeMigrator;

	public async Task<int> CreateAsync()
    {
        await SchemaBuilder.CreateMapIndexTableAsync<CustomerIndex>(table => table
            .Column<string>("Name", col => col.WithLength(256))
            .Column<string>("Email", col => col.WithLength(256))
            .Column<string>("Username", col => col.WithLength(256))
            .Column<string>("Password", col => col.WithLength(256))
        );
        return 1;
    }
}
