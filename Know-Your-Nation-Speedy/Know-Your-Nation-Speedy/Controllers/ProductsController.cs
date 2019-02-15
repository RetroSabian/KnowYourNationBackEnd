using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know_Your_Nation_Speedy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Know_Your_Nation_Speedy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext context)
        {
            _db = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _db.ProductEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            var entry = await _db.ProductEntries.SingleOrDefaultAsync(o => o.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Ok(entry);
        }


        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _db.ProductEntries.AddAsync(product);
            await _db.SaveChangesAsync();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.ProductEntries.SingleOrDefaultAsync(o => o.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.ProductEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}