using SimplesPDV.Communication.Request;
using SimplesPDV.Communication.Response;

namespace SimplesPDV.Application.Services.Product.Create;

public interface ICreateProductService
{
    Task<ResponseProductCreatedJson> Execute(RequestProductJson product);
}