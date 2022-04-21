using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private DataContext _dataContext;

        public SuppliersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet("{id}")]
        public async Task<Supplier> GetSupplierAsync(long id)
        {
            return await _dataContext.Suppliers.Include(s => 
                s.Products).FirstAsync(s => 
                s.SupplierId == id);
        }
    }
}