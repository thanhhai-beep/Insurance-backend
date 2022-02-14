using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public EmployeeController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> EmpList()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> EmpDetail(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmp(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmp(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelEmp(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("search")]
        //public async Task<IActionResult<Employee>> Search(string fname, string lname)
        //{
        //    var search = "";
        //    var emp = from e in _context.Employees
        //              select e;
        //    if (fname == null)
        //    {
        //        if (!String.IsNullOrEmpty(fname))
        //        {
        //            emp = emp.Where(s => s.Fname!.Contains(fname));
        //            //emp = emp.Where(s => s.Lname!.Contains(lname));
        //        }
        //        return search;
        //    }
        //    return search;
        //}

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
