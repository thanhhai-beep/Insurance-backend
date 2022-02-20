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
    public class RequestDetailsController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public RequestDetailsController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/RequestDetails
        [HttpGet]
        public async Task<ActionResult> GetRequestDetails()
        {
            var list = from rq in _context.RequestDetails
                       join e in _context.Employees on rq.EmpId equals e.EmpId
                       join cn in _context.CompanyDetails on rq.CompanyId equals cn.Id
                       join p in _context.Policys on rq.PolicyId equals p.Id
                       select new
                       {
                           rq,
                           e,
                           cn,
                           p
                       };
            return Ok(list);
        }

        // GET: api/RequestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDetail>> GetRequestDetail(int id)
        {
            var requestDetail = await _context.RequestDetails.FindAsync(id);

            if (requestDetail == null)
            {
                return NotFound();
            }

            return requestDetail;
        }

        // PUT: api/RequestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestDetail(int id, RequestDetail requestDetail)
        {
            if (id != requestDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestDetailExists(id))
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

        // POST: api/RequestDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestDetail>> PostRequestDetail(RequestDetail requestDetail)
        {
            _context.RequestDetails.Add(requestDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestDetail", new { id = requestDetail.Id }, requestDetail);
        }

        // DELETE: api/RequestDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestDetail(int id)
        {
            var requestDetail = await _context.RequestDetails.FindAsync(id);
            if (requestDetail == null)
            {
                return NotFound();
            }

            _context.RequestDetails.Remove(requestDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestDetailExists(int id)
        {
            return _context.RequestDetails.Any(e => e.Id == id);
        }
    }
}
