using SimplesPDV.Communication.Response;
using SimplesPDV.Domain;
using SimplesPDV.Domain.Repository;
using SimplesPDV.Domain.Repository.Product;

namespace SimplesPDV.Application.Services.Product.GetAll;

public class GetAllProducts : IGetAllProductService
{
    
    private readonly IProductReadOnlyRepository _repository;

    public GetAllProducts(IProductReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<AllProductsResponseJson> Execute()
    {
        var result = await _repository.GetAllActiveAsync();
        List<ShortProduct> shortProductList = new List<ShortProduct>();

        foreach (var products in result)
        {
            var shortProduct = new ShortProduct()
            {
                Id = products.Id,
                Name = products.Name,
                Price = products.Price,
                Quantity = products.Quantity,
                CreatedAt = products.CreatedAt,
                ModifiedAt = products.ModifiedAt,
            };
            shortProductList.Add(shortProduct);
        }
        
        return new AllProductsResponseJson(shortProductList);
    }
}