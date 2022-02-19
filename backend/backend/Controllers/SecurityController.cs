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
    public class SecurityController : ControllerBase
    {
        private readonly InsuranceDBContext _context;
        public SecurityController(InsuranceDBContext context)
        {
            _context = context;
        }

        [HttpPost("{login}")]
        public async Task<ActionResult<bool>> Login([FromForm] string email, [FromForm] string password)
        {
            if (email is null || password is null)
            {
                return BadRequest();
            }
            var login = await _context.Employees.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);
            if (login is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
