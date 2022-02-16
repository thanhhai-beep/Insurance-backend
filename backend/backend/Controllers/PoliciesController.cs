using System;
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
    public class PoliciesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public PoliciesController(InsuranceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicys()
        {
            return await _context.Policys.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _context.Policys.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            return policy;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.Id)
            {
                return BadRequest();
            }

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            _context.Policys.Add(policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicy", new { id = policy.Id }, policy);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var policy = await _context.Policys.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _context.Policys.Remove(policy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyExists(int id)
        {
            return _context.Policys.Any(e => e.Id == id);
        }
    }
}
