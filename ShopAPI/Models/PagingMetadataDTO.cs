namespace ShopAPI.Models;

public class PagingMetadataDTO {
    public int TotalItemCount { get; set; }
    public int TotalPageCount => TotalItemCount / PageSize;
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

}
