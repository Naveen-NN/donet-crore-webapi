using System.Collections.Generic;  
using WebApiProductsExample.Models;  
using System.Text.Json;  
using System.Text.Json.Serialization;  
using System.Linq; 
using Microsoft.AspNetCore.Hosting;

namespace WebApiProductsExample.Services
{
    public class  ProductService : IProductService
    {
        private static IEnumerable<Product> _products;  
        public ProductService(IWebHostEnvironment environment)
        {
            var path = @$"{environment.ContentRootPath}\mocks\products.json";
            var content = System.IO.File.ReadAllText(path); 
            _products = JsonSerializer.Deserialize<IEnumerable<Product>>(content);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products ?? new List<Product>();
        }

        public Product GetProduct(string id)
        {
            var products = GetProducts();  
            return products.Where( p => p.Id == id).SingleOrDefault();
        }
    }

}