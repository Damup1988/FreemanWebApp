using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IAsyncEnumerable<Product> GetProductsAsync()
        {
            return _dataContext.Products;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync([FromServices] ILogger<ProductsController> logger, long id)
        {
            var productToReturn = await _dataContext.Products.FindAsync(id);
            if (productToReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(productToReturn);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProductAsync([FromBody]ProductBindingTarget product)
        {
            var productToSave = product.ToProduct();
            await _dataContext.Products.AddAsync(productToSave);
            await _dataContext.SaveChangesAsync();
            return Ok(productToSave);
        }

        [HttpPut]
        public async Task UpdateProductAsync([FromBody]Product product)
        {
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteProductAsync(long id)
        {
            var productToRemove = await _dataContext.Products.FindAsync(id);
            _dataContext.Products.Remove(productToRemove);
            await _dataContext.SaveChangesAsync();
        }
    }
}