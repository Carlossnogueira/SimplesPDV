using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplesPDV.Application.Services.Product.Create;
using SimplesPDV.Domain.Repository;

namespace SimplesPDV.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCases(services);
    }
    
    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateProductService, CreateProductService>();
    }

}