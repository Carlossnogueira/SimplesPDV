namespace SimplesPDV.Domain.Front;

public class ProductPagination
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public ProductPagination(int currentPage, int pageSize, int totalItems, int totalPagesCount)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = totalPagesCount;
    }
}