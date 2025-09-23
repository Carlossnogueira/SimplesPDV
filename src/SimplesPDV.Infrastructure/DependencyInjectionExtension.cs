using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplesPDV.Domain.Repository;

namespace SimplesPDV.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SimplesPDVContext>(config => config.UseNpgsql(connectionString));
    }
    
}