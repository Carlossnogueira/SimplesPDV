using SimplesPDV.Communication.Response.Front.Pagination;
using SimplesPDV.Domain;
using SimplesPDV.Domain.Front;
using SimplesPDV.Domain.Repository.Product;

namespace SimplesPDV.Application.Services.Product.GetAll;

public class GetPaginatedProducts : IGetPaginatedProducts
{
    private readonly IProductReadOnlyRepository _repository;

    public GetPaginatedProducts(IProductReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseProductPaginationJson> Execute(int page, int pageSize)
    {
        
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        
        var totalItens = await _repository.GetCountAsync();
        var totalPages = (int)Math.Ceiling(totalItens / (double)pageSize);
        var pagination = new ProductPagination(page, pageSize, totalItens, totalPages);

        var paginatedProduct = new ProductPagination(page, pageSize, totalItens, totalPages);
        
        var products = await _repository.GetPaginatedProductsAsync(page, pageSize);
        var shortProducts = new List<ShortProduct>();

        foreach (var product in products) 
        {
            var shortProdut = new ShortProduct();
            
            shortProdut.Id = product.Id;
            shortProdut.Name = product.Name;
            shortProdut.Price = product.Price;
            shortProdut.Quantity = product.Quantity;
            shortProdut.CreatedAt = product.CreatedAt;
            shortProdut.ModifiedAt = product.ModifiedAt;
            
            shortProducts.Add(shortProdut);
        }
        
        return new ResponseProductPaginationJson(shortProducts, pagination);
        
    }
}