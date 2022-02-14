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
    public class PolicyApprovalController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public PolicyApprovalController(InsuranceDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalDetail>>> GetApproval()
        {
            return await _context.ApprovalDetails.ToListAsync();
        }

        //get id
        [HttpGet("{id}")]
        public async Task<ActionResult<ApprovalDetail>> GetApprovals(int id)
        {
            var app = await _context.ApprovalDetails.FindAsync(id);

            if (app == null)
            {
                return NotFound();
            }
            return app;
        }

        //post
        //[HttpPost]
        //public async Task<ActionResult<ApprovalDetail>> PostApproval(ApprovalDetail approval)
        //{
        //    if (approval.Status) //lỗi dòng lõ này
        //    {
        //        var policyRequest = _context.ApprovalDetails.Find(approval.RequestId);
        //        var policy = new Policy()
        //        {
        //            Id = policyRequest.Id,

        //        };
        //        _context.Policys.Add(policy);
        //    }

        //    _context.ApprovalDetails.Add(approval);

        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetPolicyApproval", new { id = approval.Id }, approval);
        //}

        //put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyApproval(int id, ApprovalDetail approval)
        {
            if (id != approval.Id)
            {
                return BadRequest();
            }
            _context.Entry(approval).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyApprovalExists(id))
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

        private bool PolicyApprovalExists(int id)
        {
            return _context.ApprovalDetails.Any(e => e.Id == id);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApprovalDetail>> DeleteApproval(int id)
        {
            var app = await _context.ApprovalDetails.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }
            _context.ApprovalDetails.Remove(app);
            await _context.SaveChangesAsync();
            return app;
        }
    }
}