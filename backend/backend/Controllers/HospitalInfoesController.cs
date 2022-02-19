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
    public class HospitalInfoesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public HospitalInfoesController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/HospitalInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalInfo>>> GetHospitalInfos(string searchname)
        {
            var hos = from hp in _context.HospitalInfos select hp;
            if (searchname != null)
            {
                hos = hos.Where(s => s.HospitalName.Contains(searchname));
                return Ok(hos);
            }
            return Ok(hos);
        }

        // GET: api/HospitalInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalInfo>> GetHospitalInfo(int id)
        {
            var hospitalInfo = await _context.HospitalInfos.FindAsync(id);

            if (hospitalInfo == null)
            {
                return NotFound();
            }

            return hospitalInfo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalInfo(int id, HospitalInfo hospitalInfo)
        {
            if (id != hospitalInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalInfoExists(id))
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

        // POST: api/HospitalInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospitalInfo>> PostHospitalInfo(HospitalInfo hospitalInfo)
        {
            _context.HospitalInfos.Add(hospitalInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalInfo", new { id = hospitalInfo.Id }, hospitalInfo);
        }

        // DELETE: api/HospitalInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalInfo(int id)
        {
            var hospitalInfo = await _context.HospitalInfos.FindAsync(id);
            if (hospitalInfo == null)
            {
                return NotFound();
            }

            _context.HospitalInfos.Remove(hospitalInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalInfoExists(int id)
        {
            return _context.HospitalInfos.Any(e => e.Id == id);
        }
    }
}
