using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        //todo
        //check if it need to be replaced with interface
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //todo
                //one class should be responsible only for one thing
                if (context.Products.Any() == false)
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    products.ForEach(item => { context.Products.Add(item); });

                    await context.SaveChangesAsync();
                }

                if (context.Customers.Any() == false)
                {
                    var customerData = File.ReadAllText("../Infrastructure/Data/SeedData/customers.json");
                    var customers = JsonSerializer.Deserialize<List<Customer>>(customerData);

                    customers.ForEach(item => { context.Customers.Add(item); });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
