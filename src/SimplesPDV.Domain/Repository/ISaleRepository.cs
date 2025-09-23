namespace SimplesPDV.Domain.Repository;

public interface ISaleRepository
{
    Task Add(Sale sale);
    Task <List<Sale>> GetAll();
    Task<List<Product>> GetByDate(DateOnly date);
    Task Update(long id, Sale sale);
    Task Delete(long id);
}