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
    public class PolicyRequestController : ControllerBase
    {
        //private readonly InsuranceDBContext _context;

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RequestDetail>>> GetPolicyRequest()
        //{
        //    return await _context.RequestDetails
        //    .Include(pr => pr.Policy)
        //    .Include(pr => pr.Employee)
        //    .Where(pr => !pr.Status)
        //    .ToListAsync();
        //}

        //[HttpGet("UserRequests/{id}")]
        //public async Task<ActionResult<IEnumerable<RequestDetail>>> GetPolicyRequestForEmployee(int id)
        //{
        //    return await _context.RequestDetails
        //    .Include(pr => pr.Policy)
        //    .Include(pr => pr.Employee)
        //    .Where(pr => !pr.Retired && pr.EmployeeId == id)
        //    .ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<RequestDetail>> GetPolicyRequest(int id)
        //{
        //    var policyRequest = await _context.RequestDetails
        //    .Include(pr => pr.Policy)
        //    .Include(pr => pr.Employee)
        //    .Where(pr => !pr.Retired && pr.RequestId == id)
        //    .FirstOrDefaultAsync();

        //    if (policyRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return policyRequest;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPolicyRequest(int id, RequestDetail requestDetail)
        //{
        //    if (id != requestDetail.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(requestDetail).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PolicyRequestExists(id))
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

        //[HttpPost]
        //public async Task<ActionResult<RequestDetail>> PostPolicyRequest(RequestDetail requestDetail)
        //{
        //    _context.RequestDetails.Add(requestDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPolicyRequest", new { id = requestDetail.Id }, requestDetail);
        //}

        //// DELETE: api/PolicyRequests/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<RequestDetail>> DeletePolicyRequest(int id)
        //{
        //    var policy = await _context.RequestDetails.FindAsync(id);
        //    if (policy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.RequestDetails.Remove(policy);
        //    await _context.SaveChangesAsync();

        //    return policy;
        //}

        //private bool PolicyRequestExists(int id)
        //{
        //    return _context.RequestDetails.Any(r => r.Id == id);
        //}

    }
}
