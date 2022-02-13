﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public EmployeesController(InsuranceDBContext context)
        {
            _context = context;
        }

        //// GET: api/Employees
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> EmpList()
        //{
        //    return await _context.Employee.ToListAsync();
        //}

        //// GET: api/Employees/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> EmpDetail(int id)
        //{
        //    var employee = await _context.Employee.FindAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return employee;
        //}

        //// PUT: api/Employees/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
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

        //// POST: api/Employees
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Employee>> AddEmp(Employee employee)
        //{
        //    _context.Employee.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        //}

        //// DELETE: api/Employees/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DelEmp(int id)
        //{
        //    var employee = await _context.Employee.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employee.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        ////[HttpGet]
        ////public async Task<ActionResult<IEnumerable<Employee>>> SearchEmp(string name)
        ////{
        ////    var searchname = "";
        ////    var emp = from m in _context.Employee
        ////                 select m;
        ////    if (name != null)
        ////    {
        ////        if (!String.IsNullOrEmpty(searchString))
        ////        {
        ////            movies = movies.Where(s => s.Title!.Contains(searchString));
        ////        }
        ////        return searchname;
        ////    }
        ////    return searchname;
        ////}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employee.Any(e => e.EmpId == id);
        //}
    }
}
