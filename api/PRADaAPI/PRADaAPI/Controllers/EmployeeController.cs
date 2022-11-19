using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace PRADaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly POSContext _context;

        public EmployeeController(POSContext context)
        {
            _context = context;

            if (_context.Employees.Count() == 0)
            {
                _context.Employees.Add(
                    new Employee
                    {
                        Id = 1,
                        Name = "Employee1_Name",
                        Lastname = "Employee1_Lastname",
                        Email = "Employee1_Email",
                        EmployeeCardCode = "Employee1_CardCode"
                    }
                );
                _context.SaveChanges();
            }
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeItem()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeItem(long id)
        {
            var EmployeeItem = await _context.Employees.FindAsync(id);

            if (EmployeeItem == null)
            {
                return NotFound();
            }

            return EmployeeItem;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(ulong id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployeeItem(Employee Employee)
        {
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = Employee.Id }, Employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(ulong id)
        {
            var Employee = await _context.Employees.FindAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employee);
            await _context.SaveChangesAsync();

            return Employee;
        }

        private bool EmployeeExists(ulong id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "John",
                    Lastname = "Smith",
                    Email = "John.Smith@gmail.com",
                    EmployeeCardCode = "1111111111111"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Jane",
                    Lastname = "Doe",
                    Email = "Jane.Doe@gmail.com",
                    EmployeeCardCode = "22222222222"
                }
            };
        }
        [HttpGet("{employeeCardCode}")] //1st Cashier user story
        public async Task<ActionResult<Employee>> GetEmployeeByCode(string EmployeeCardCode)
        {
            List<Employee> Employees = new List<Employee>();
            Employees = GetEmployees();
            var Employee = new Employee()
            {
                Id = 1,
                Name = "John",
                Lastname = "Smith",
                Email = "John.Smith@gmail.com",
                EmployeeCardCode = "1111111111111"
            };
            /*
            bool request = false;
            foreach (var employee in Employees)
            {
                if (EmployeeCardCode == employee.EmployeeCardCode)
                {
                    request = true;
                    return employee;
                }
            }
            */
            if (Employee == null)
            {
                return BadRequest();
            }
            else return NoContent();

        }
    }
}
