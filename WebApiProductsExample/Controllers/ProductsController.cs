using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiProductsExample.Services;  
using WebApiProductsExample.Models;  
using Microsoft.AspNetCore.Http;  

namespace WebApiProductsExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService = null;  
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetProducts([FromQuery]string maker = "")
        {
           IEnumerable<Product> products  =  null;  
           try
           {
             
              products = _productService.GetProducts();  
             
              if(products != null && products.Any() && !string.IsNullOrWhiteSpace(maker))
              {
                  products = products.Where( p => p.Maker.ToLowerInvariant().Contains(maker.ToLowerInvariant()));
              }
           }
           catch
           {
               return StatusCode(StatusCodes.Status500InternalServerError);
           }
           return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) return BadRequest();  

           Product product  =  null;  
           try
           {
              product = _productService.GetProduct(id); 
              
              if(product == null) 
              {
                  return NotFound();
              }
           }
           catch
           {
               return StatusCode(StatusCodes.Status500InternalServerError);
           }

           return Ok(product);
        }
    }
}