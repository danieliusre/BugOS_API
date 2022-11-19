using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;

namespace PRADaAPI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly POSContext _context;

        public CategoryController(POSContext context)
        {
            _context = context;

            if (_context.Categories.Count() == 0)
            {
                _context.Categories.Add(
                    new Category
                    {
                        Id = 1,
                        Name = "category1",
                        Description = "category",
                        Discount = 1
                    }
                );
                _context.SaveChanges();
            }
        }

        // POST: api/Order
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategoryItem(Category Category)
        {
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = Category.Id }, Category);
        }
    }
}