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
        //private readonly InsuranceDBContext _context;

        //public EmployeeController(InsuranceDBContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Employees
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> EmpList()
        //{
        //    return await _context.Employees.ToListAsync();
        //}

        //// GET: api/Employees/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> EmpDetail(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return employee;
        //}

        //public async Task<IActionResult> UpdateEmp(int id, Employee employee)
        //{
        //    if (id != employee.EmpId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //public async Task<ActionResult<Employee>> AddEmp(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DelEmp(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> SearchEmp(string name)
        //{
        //    var searchname = "";
        //    var emp = from e in _context.Employees
        //              select e;
        //    if (name != null)
        //    {
        //        if (!String.IsNullOrEmpty(name))
        //        {
        //            emp = emp.Where(s => s.!.Contains(searchString));
        //        }
        //        return searchname;
        //    }
        //    return searchname;
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.EmpId == id);
        //}
    }
}
