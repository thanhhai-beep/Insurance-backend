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
    public class CompanyDetailsController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public CompanyDetailsController(InsuranceDBContext context)
        {
            _context = context;
        }

        //Get all list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDetail>>> GetInsuranceCompany()
        {
            return await _context.CompanyDetails.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetail>> GetInsuranceCompany(int id)
        {
            var insurance = await _context.CompanyDetails.FindAsync(id);

            if (insurance == null)
            {
                return NotFound();
            }
            return insurance;
        }

        //Post insurance
        [HttpPost]
        public async Task<ActionResult<CompanyDetail>> PostInsuranceCompany(CompanyDetail companyDetail)
        {
            _context.CompanyDetails.Add(companyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceCompany", new { id = companyDetail.Id }, companyDetail);
        }

        //Put Insurance
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceCompany(int id, CompanyDetail companyDetail)
        {
            if (id != companyDetail.Id)
            {
                return BadRequest();
            }

            // _context.Entry(insuranceCompany).State = EntityState.Modified;
            _context.CompanyDetails.Update(companyDetail);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompanyExists(id))
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
        public async Task<ActionResult<CompanyDetail>> DeleteCompanyInsurance(int id)
        {
            var insurance = await _context.CompanyDetails.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }
            //insurance.Id = true;
            _context.CompanyDetails.Update(insurance);
            await _context.SaveChangesAsync();
            return insurance;
        }

        private bool InsuranceCompanyExists(int id)
        {
            return _context.CompanyDetails.Any(e => e.Id == id);
        }


        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<CompanyDetail>>> Search(string CompanyName)
        {
            var query = _context.CompanyDetails.Include(cpn => cpn.CompanyName).AsQueryable();

            if (CompanyName != null)
            {
                query = query.Where(c => c.CompanyName.Contains(CompanyName.Trim()));
            }
            return await query.ToListAsync();
        }
    }
}
