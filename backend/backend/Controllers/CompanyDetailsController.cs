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
    public class CompanyDetailsController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public CompanyDetailsController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/CompanyDetails
        [HttpGet]
        public async Task<ActionResult> GetCompanyDetails(string searchname)
        {
            var company = from cn in _context.CompanyDetails select cn;
            if (searchname != null)
            {
                company = company.Where(s => s.CompanyName.Contains(searchname));
                return Ok(company);
            }
            return Ok(company);
        }

        // GET: api/CompanyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetail>> GetCompanyDetail(int id)
        {
            var companyDetail = await _context.CompanyDetails.FindAsync(id);

            if (companyDetail == null)
            {
                return NotFound();
            }
            return companyDetail;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyDetail(int id, CompanyDetail companyDetail)
        {
            if (id != companyDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailExists(id))
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

        // POST: api/CompanyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyDetail>> PostCompanyDetail(CompanyDetail companyDetail)
        {
            _context.CompanyDetails.Add(companyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyDetail", new { id = companyDetail.Id }, companyDetail);
        }

        // DELETE: api/CompanyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyDetail(int id)
        {
            var companyDetail = await _context.CompanyDetails.FindAsync(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            _context.CompanyDetails.Remove(companyDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyDetailExists(int id)
        {
            return _context.CompanyDetails.Any(e => e.Id == id);
        }
    }
}
