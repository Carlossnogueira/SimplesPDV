namespace SimplesPDV.Domain;

public class Product
{
    public long Id {get; set;}
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; } 
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}