using SimplesPDV.Domain.Enum;

namespace SimplesPDV.Domain;

public class Sale
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public PaymentType PaymentType { get; set; }
    public Boolean IsCancelled { get; set; }
    
    public ICollection<SaleItem> Items { get; set; } =  new List<SaleItem>();
}