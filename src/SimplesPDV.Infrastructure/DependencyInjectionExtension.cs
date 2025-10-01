using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplesPDV.Domain.Repository;
using SimplesPDV.Domain.Repository.Product;
using SimplesPDV.Infrastructure.Repository;

namespace SimplesPDV.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddUnityOfWork(services);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
        services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
    }

    private static void AddUnityOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SimplesPDVContext>(config => config.UseNpgsql(connectionString));
    }


}