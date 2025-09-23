namespace SimplesPDV.Domain.Repository;

public interface ISaleItemRepository
{
    Task Add(SaleItem saleItem);
    Task <List<SaleItem>> GetAll();
    Task<List<SaleItem>> GetById(long id);
    Task Update(long id, SaleItem saleItem);
    Task Delete(long id);
}