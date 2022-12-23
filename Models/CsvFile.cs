using CsvHelper.Configuration.Attributes;

namespace ProductFilter.Models;
public class CsvFile
{
    [Name("sellerId")]
    public string? SellerId { get; set; }

    [Name("productId")]
    public string? ProductId { get; set; }
}