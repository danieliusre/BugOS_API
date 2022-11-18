using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;

            if (_context.Orders.Count() == 0)
            {
                _context.Orders.Add(new Order
                {
                    Id = 1,
                    Status = 1,
                    CreationDate = "2011-11-11",
                    CompletionDate = "2022-11-11",
                    Discount = 1,
                    Employee = 1,
                    Customer = 1
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderItem()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderItem(long id)
        {
            var OrderItem = await _context.Orders.FindAsync(id);

            if (OrderItem == null)
            {
                return NotFound();
            }

            return OrderItem;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(ulong id, Order Order)
        {
            if (id != Order.Id)
            {
                return BadRequest();
            }

            _context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrderItem(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = Order.Id }, Order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(ulong id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return Order;
        }

        private bool OrderExists(ulong id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        private List<Order> GetOrders()
    {
        return new List<Order>()
        {
            new Order()
            {
                Id = 1,
                Name= "John",
                Lastname = "Smith",
                Email ="John.Smith@gmail.com",
                Password = "1",
                Address = " adresas "
            },
            new Order()
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
