using Microsoft.EntityFrameworkCore;
using SimplesPDV.Domain;

namespace SimplesPDV.Infrastructure;

public class SimplesPDVContext : DbContext
{
    public SimplesPDVContext(DbContextOptions<SimplesPDVContext> options) : base(options){}
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
}