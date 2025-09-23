namespace SimplesPDV.Domain;

public class SaleItem
{
    public long Id { get; set; }
    public long SaleId { get; set; }
    public Sale Sale { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}