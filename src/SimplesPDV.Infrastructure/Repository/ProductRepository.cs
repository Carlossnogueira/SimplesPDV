using Microsoft.EntityFrameworkCore;
using SimplesPDV.Domain;
using SimplesPDV.Domain.Repository.Product;

namespace SimplesPDV.Infrastructure.Repository;

public class ProductRepository : IProductReadOnlyRepository, IProductWriteOnlyRepository
{

    private readonly SimplesPDVContext _context;

    public ProductRepository(SimplesPDVContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Product product)
    { 
        await _context.Products.AddAsync(product);
    }

    public async Task<List<Product>> GetAllActiveAsync()
    {
        return await _context.Products.Where(p => !p.IsDeleted).AsNoTracking().ToListAsync();
    }

    public async Task<List<Product>> GetAllIncluingDeletedAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<List<Product>> GetPaginatedProductsAsync(int page, int pageSize)
    {
        return await _context.Products
            .OrderBy(p => p.Id)
            .Skip((page -1) * pageSize)
            .Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Products.AsNoTracking().CountAsync();
    }

    public async Task<List<Product>> GetByNameAsync(string name)
    {
        return await _context.Products.Where(p => p.Name.Contains(name)).AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(long id, Product product)
    {
        await _context.Products.Where(p  => p.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(p => p.Name, product.Name)
            .SetProperty(p => p.Price, product.Price)
            .SetProperty(p => p.Quantity, product.Quantity)
            .SetProperty(p => p.IsDeleted, product.IsDeleted)
        );
    }

    public async Task DeleteAsync(long id)
    {
        await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
    }

    public async Task SoftDeleteAsync(long id)
    {
        await _context.Products.Where(p => p.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(p => p.IsDeleted, true));
    }
}