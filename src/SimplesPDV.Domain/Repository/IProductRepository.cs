namespace SimplesPDV.Domain.Repository;

public interface IProductRepository
{
    Task Add(Product product);
    Task <List<Product>> GetAll();
    Task<List<Product>> GetByName(string name);
    Task Update(long id, Product product);
    Task Delete(long id);
}