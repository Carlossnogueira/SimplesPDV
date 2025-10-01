using SimplesPDV.Domain;
using SimplesPDV.Domain.Front;

namespace SimplesPDV.Communication.Response.Front.Pagination;

public class ResponseProductPaginationJson
{
    public List<ShortProduct> Products { get; set; }
    public Domain.Front.ProductPagination Pagination { get; set; }

    public ResponseProductPaginationJson(List<ShortProduct> products, Domain.Front.ProductPagination pagination)
    {
        Products = products;
        Pagination = pagination;
    }
}