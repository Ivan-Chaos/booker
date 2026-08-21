using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Booker.Api.Data;

// Used by `dotnet ef` at design time.
public class BookerContextFactory : IDesignTimeDbContextFactory<BookerContext>
{
    public BookerContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<BookerContextFactory>()
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("BookerDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            // Generating migrations does not require a reachable database.
            connectionString = "Host=localhost;Port=5432;Database=booker;Username=postgres";
        }

        var optionsBuilder = new DbContextOptionsBuilder<BookerContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new BookerContext(optionsBuilder.Options);
    }
}
