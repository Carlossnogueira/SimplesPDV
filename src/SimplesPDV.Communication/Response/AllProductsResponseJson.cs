using SimplesPDV.Domain;

namespace SimplesPDV.Communication.Response;

public class AllProductsResponseJson
{
    public List<ShortProduct> Products { get; set; }
    
    public AllProductsResponseJson(List<ShortProduct> products)
    {
        Products = products;
    }

    public AllProductsResponseJson()
    {
        
    }
}