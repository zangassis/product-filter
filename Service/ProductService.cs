using CsvHelper;
using CsvHelper.Configuration;
using ProductFilter.Models;
using System.Globalization;

namespace ProductFilter.Service;

public class ProductService
{
    public void ExecuteService()
    {
        var filteredProducts = new List<CsvFile>();

        ReadCsvFile(filteredProducts);
        WriteCsvFile(filteredProducts);
    }

    public void ReadCsvFile(List<CsvFile> filteredProducts)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using (var reader = new StreamReader("C:\\Users\\assis.zang\\Documents\\Files\\products.csv"))
        {
            using (var csv = new CsvReader(reader, config))
            {
                var products = csv.GetRecords<CsvFile>().ToList();

                foreach (var product in products)
                {
                    var repeatSeller = products.FindAll(p => p.SellerId == product.SellerId);
                    var filteredProductsAlreadyContainsSeller = filteredProducts.Where(p => p.SellerId == product.SellerId).ToList();

                    if (repeatSeller.Count > 1 && !filteredProductsAlreadyContainsSeller.Any())
                        filteredProducts.Add(product);
                }
            }
        }
    }

    public void WriteCsvFile(List<CsvFile> filteredProducts)
    {
        using (var writer = new StreamWriter("C:\\Users\\assis.zang\\Documents\\Files\\producstFiltered.csv"))
        {
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CsvFileMap>();
                csv.WriteHeader<CsvFile>();
                csv.NextRecord();
                csv.WriteRecords(filteredProducts);
            }
        }
    }
}