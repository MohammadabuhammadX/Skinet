using System.Text.Json;
using Microsoft.Extensions.Logging;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                // Check if database exists and create if not
                await context.Database.EnsureCreatedAsync();

                // Begin transaction for IDENTITY_INSERT
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    // ProductBrands seeding with IDENTITY_INSERT
                    if (!context.ProductBrands.Any())
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductBrands ON");
                        var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                        await context.ProductBrands.AddRangeAsync(brands);
                        await context.SaveChangesAsync();
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductBrands OFF");
                    }

                    // ProductTypes seeding with IDENTITY_INSERT
                    if (!context.ProductTypes.Any())
                    {
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductTypes ON");
                        var typesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                        await context.ProductTypes.AddRangeAsync(types);
                        await context.SaveChangesAsync();
                        await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductTypes OFF");
                    }

                    // Products seeding (no IDENTITY_INSERT needed)
                    if (!context.Products.Any())
                    {
                        var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                        await context.Products.AddRangeAsync(products);
                        await context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger("DatabaseSeed");
                logger.LogError(ex, "An error occurred while seeding the database");
                throw;
            }
        }
    }
}