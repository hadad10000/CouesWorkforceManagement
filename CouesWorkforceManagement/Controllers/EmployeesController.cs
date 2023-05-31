using CouesWorkforceManagement.DAL;
using CouesWorkforceManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouesWorkforceManagement.Controllers
{
    // EmployeesController.cs
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly WorkforceDbContext _context;

        public EmployeesController(WorkforceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }


}

