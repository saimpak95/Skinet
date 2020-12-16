using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet_DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Skinet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext db;

        public ProductsController(DataContext db)
        {
            this.db = db;
        
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await db.Products.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await db.Products.Where(x => x.Id == id).FirstOrDefaultAsync());
        }
    }
}
