using SimplesPDV.Communication.Response;

namespace SimplesPDV.Application.Services.Product.GetAll;

public interface IGetAllProductService
{
    Task<AllProductsResponseJson> Execute();
}