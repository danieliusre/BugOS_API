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
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : Controller
    {
         private readonly POSContext _context;

        public ShiftController(POSContext context)
        {
            _context = context;

            if (_context.Shifts.Count() == 0)
            {
                _context.Shifts.Add(
                    new Shift
                    {
                        Id = 1,
                        Employee = 1,
                        StartDate = new DateTime(1111, 11, 11),
                        EndDate = new DateTime(1111, 11, 11),
                    }
                );
                _context.SaveChanges();
            }
        }

        // GET: api/Shifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shift>>> GetShifts()
        {
            return await _context.Shifts.ToListAsync();
        }

        // PUT: api/Shift/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(ulong id, Shift Shift)
        {
            if (id != Shift.Id)
            {
                return BadRequest();
            }

            _context.Entry(Shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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

        private bool ShiftExists(ulong id)
        {
            return _context.Shifts.Any(e => e.Id == id);
        }


    }
}