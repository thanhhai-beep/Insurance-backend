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
    public class HospitalController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public HospitalController(InsuranceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalInfo>>> GetHospital()
        {
            return await _context.HospitalInfos.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalInfo>> GetHospitals(int id)
        {
            var hos = await _context.HospitalInfos.FindAsync(id);

            if (hos == null)
            {
                return NotFound();
            }
            return hos;
        }

        [HttpPost]
        public async Task<ActionResult<HospitalInfo>> PostHospital(HospitalInfo hospital)
        {
            _context.HospitalInfos.Add(hospital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospital(int id, HospitalInfo hospital)
        {
            if (id != hospital.Id)
            {
                return BadRequest();
            }

            //_context.Entry(hospital).State = EntityState.Modified;
            _context.Update(hospital);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(hospital);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalInfo>> DeleteHospital(int id)
        {
            var hos = await _context.HospitalInfos.FindAsync(id);
            if (hos == null)
            {
                return NotFound();
            }
            _context.HospitalInfos.Remove(hos);
            await _context.SaveChangesAsync();

            return hos;
        }

        private bool HospitalExists(int id)
        {
            return _context.HospitalInfos.Any(e => e.Id == id);
        }


        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<HospitalInfo>>> Search([FromForm] string HospitalName, [FromForm] string Phone, [FromForm] string Address)
        {
            var query = _context.HospitalInfos.Include(ar => ar.Address).AsQueryable();

            if (HospitalName != null)
            {
                query = query.Where(h => h.HospitalName.Contains(HospitalName));
            }
            if (Address != null)
            {
                query = query.Where(a => a.Address.Contains(Address));
            }

            if (Phone != null)
            {
                query = query.Where(p => p.Phone.Contains(Phone));
            }
            return await query.ToListAsync();
        }

    }
}
