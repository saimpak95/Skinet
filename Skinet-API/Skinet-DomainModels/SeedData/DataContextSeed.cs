using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skinet_DomainModels.SeedData
{
   public static class DataContextSeed
    {
        public static async Task SeedAsync(DataContext db, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!db.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Skinet-DomainModels/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach (var item in brands)
                    {
                        db.ProductBrands.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
                if (!db.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("../Skinet-DomainModels/SeedData/types.json");
                    var type = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    foreach (var item in type)
                    {
                        db.ProductTypes.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
                if (!db.Products.Any())
                {
                    var productData = File.ReadAllText("../Skinet-DomainModels/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        db.Products.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message, "An error occur during Data seeding");
                
            }
        }
    }
}
