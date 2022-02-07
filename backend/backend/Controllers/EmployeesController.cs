using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _emp;
        public EmployeesController(IEmployee emp)
        {
            _emp = emp;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> ListEmp()
        {
            return await _emp.getEmps();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            return await _emp.empDetail(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee emp)
        {
            var em = await _emp.addEmp(emp);
            return CreatedAtAction(nameof(ListEmp), new { id = em.empId }, em);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employee emp)
        {
            if (id != emp.empId)
            {
                return BadRequest();
            }
            await _emp.updateEmp(emp);
            return NoContent();
        }
    }
}
