using SimplesPDV.Communication.Response.Front.Pagination;

namespace SimplesPDV.Application.Services.Product.GetAll;

public interface IGetPaginatedProducts
{
    Task<ResponseProductPaginationJson> Execute(int page, int pageSize);
}