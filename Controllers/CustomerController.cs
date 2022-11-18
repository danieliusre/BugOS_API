using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CustomerApi.Models;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;

            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(new Customer
                {
                    Id = 1,
                    Name = "Customer1_Name",
                    Lastname = "Customer1_Lastname",
                    Email = "Customer1_Email",
                    Password = "password",
                    Address = "adress"
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerItem()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerItem(long id)
        {
            var CustomerItem = await _context.Customers.FindAsync(id);

            if (CustomerItem == null)
            {
                return NotFound();
            }

            return CustomerItem;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(ulong id, Customer Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomerItem(Customer Customer)
        {
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(ulong id)
        {
            var Customer = await _context.Customers.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();

            return Customer;
        }

        private bool CustomerExists(ulong id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        private List<Customer> GetCustomers()
    {
        return new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Name= "John",
                Lastname = "Smith",
                Email ="John.Smith@gmail.com",
                Password = "1",
                Address = " adresas "
            },
            new Customer()
            {
                Id = 2,
                Name= "Jane",
                Lastname = "Doe",
                Email ="Jane.Doe@gmail.com",
                Password = "22",
                Address = " adresas2 "
            }
        };
    }
    }
}
