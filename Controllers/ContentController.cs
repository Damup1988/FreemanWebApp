using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private DataContext _dataContext;

        public ContentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("string")]
        public string GetString() => "This is a string response";

        [HttpGet("object")]
        public async Task<Product> GetObject()
        {
            return await _dataContext.Products.FirstAsync();
        }
    }
}