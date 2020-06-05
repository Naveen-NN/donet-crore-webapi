using System.Collections.Generic;  
using WebApiProductsExample.Models;  

namespace WebApiProductsExample.Services
{
    public interface  IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string id);

    }

}