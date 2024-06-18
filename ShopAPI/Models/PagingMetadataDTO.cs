namespace ShopAPI.Models;

public class PagingMetadataDTO<T> {
    public int TotalItemCount { get; set; }
    public int TotalPageCount => TotalItemCount / PageSize;
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public T Items { get; set; }
}
