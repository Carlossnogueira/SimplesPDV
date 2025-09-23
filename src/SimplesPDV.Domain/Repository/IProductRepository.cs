namespace SimplesPDV.Domain.Repository;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task <List<Product>> GetAllActiveAsync();
    Task<List<Product>> GetAllIncluingDeletedAsync();
    Task<List<Product>> GetByNameAsync(string name);
    Task UpdateAsync(long id, Product product);
    Task DeleteAsync(long id);
    Task SoftDeleteAsync(long id);
}