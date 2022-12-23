using CsvHelper.Configuration;

namespace ProductFilter.Models;
public class CsvFileMap : ClassMap<CsvFile>
{
    public CsvFileMap()
    {
        Map(m => m.SellerId).Name("sellerId");
        Map(m => m.ProductId).Name("productId");
    }
}
