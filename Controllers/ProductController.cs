using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using POSApi.Models;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly POSContext _context;

        public ProductController(POSContext context)
        {
            _context = context;
             if (_context.Products.Count() == 0)
            {
                _context.Products.Add(
                    new Product
                    {
                        Id = 1,
                        Name = "product1",
                        Description = "aaaaaaaaaaaa",
                        Price = 1,
                        Stock = 1,
                        Barcode = "a1a1a1a1a1",
                        Category = 1,
                        Discount = 1
                    }
                );
                _context.SaveChanges();
            }
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductItem()
        {
            return await _context.Products.ToListAsync();
        }

         // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductItem(long id)
        {
            var ProductItem = await _context.Products.FindAsync(id);

            if (ProductItem == null)
            {
                return NotFound();
            }

            return ProductItem;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(ulong id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            _context.Entry(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

         // POST: api/Product
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProductItem(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = Product.Id }, Product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(ulong id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return Product;
        }

        private bool ProductExists(ulong id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "product1",
                    Description = "aaaaaaaaaaaa",
                    Price = 1,
                    Stock = 1,
                    Barcode = "a1a1a1a1a1",
                    Category = 1,
                    Discount = 1
                },
            };
        }
    }
}