using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductsMicroservice.Models;

namespace ProductsMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private static readonly string[] Products = new[]
        {
            "Pc", "Phone", "Tv"
        };

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var rng = new Random(Guid.NewGuid().GetHashCode());
            return Enumerable.Range(1, Products.Length)
                .Select(index => new Product
                {
                    ProductId = index,
                    Name = Products[index-1],
                    Price = rng.Next(10, 100)
                }).ToArray();
        }
    }
}
