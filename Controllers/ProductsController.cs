using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _dataContext.Products;
        }

        [HttpGet("{id}")]
        public IQueryable<Product> GetProduct([FromServices] ILogger<ProductsController> logger, long id)
        {
            logger.LogDebug("GetProduct Action Invoked");
            return _dataContext.Products.Where(p => p.ProductId == id);
        }

        [HttpPost]
        public void SaveProduct([FromBody]Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }
    }
}