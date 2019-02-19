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
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductController(MyDbContext context)
        {
            _db = context;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {

            //var list = _db.ProductEntries.Select(o => o.Name).ToList();

            //return Ok(list);

            return await _db.ProductEntries.ToListAsync();
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            var entry = _db.ProductEntries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Ok(entry);
        }


        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product.Name == null && product.SizeOption == null && product.Type == null && product.ColourOption == null)
            {
                return BadRequest(new { Error = "product not fully loaded" });
            }
            else
            {
                _db.ProductEntries.AddAsync(product);
                _db.SaveChangesAsync();
                return Ok(product);
            }
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

        [HttpGet("getproduct")]
        public async Task<ActionResult<IEnumerable<Product>>> Get(int id)
        {
            var list = _db.ProductEntries.Where(o => o.Id == id);

            return Ok(list.ToList());
        }


        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<Product>>> Get(string type)
        {
            var list = _db.ProductEntries.Where(o => o.Type == type);

            return Ok(list.ToList());
        }
    }
}