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

namespace POSApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventHistoryController : Controller
    {
        private readonly POSContext _context;

        public EventHistoryController(POSContext context)
        {
            _context = context;

            if (_context.EventHistories.Count() == 0)
            {
                _context.EventHistories.Add(
                    new EventHistory
                    {
                        Id = 1,
                        Date = new DateTime(1111, 11, 11),
                        EventInformation = "aaaaaaaaaaaaaa",
                        Employee = 1
                    }
                );
                _context.SaveChanges();
            }
        }
        
        // GET: api/EventHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventHistory>>> GetEventHistory()
        {
            return await _context.EventHistories.ToListAsync();
        }

        // GET: api/EventHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventHistory>> GetEventHistory(long id)
        {
            var EventHistoryItem = await _context.EventHistories.FindAsync(id);

            if (EventHistoryItem == null)
            {
                return NotFound();
            }

            return EventHistoryItem;
        }
    }
}